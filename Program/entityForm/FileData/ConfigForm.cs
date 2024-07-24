﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ConfigUpdater
{
    public partial class ConfigForm : Form
    {
        private const string ConfigFilePath = "Configurations.xml";

        public ConfigForm()
        {
            InitializeComponent();
            LoadConfigurations();
            LoadCurrentConfiguration();
        }

        private void LoadCurrentConfiguration()
        {
            try
            {
                var settings = ConfigurationManager.ConnectionStrings["Program.Properties.Settings.WarehouseConnectionString"].ConnectionString;
                var connectionStringParts = settings.Split(';')
                    .Select(part => part.Split('='))
                    .Where(split => split.Length == 2)
                    .ToDictionary(split => split[0].Trim(), split => split[1].Trim());

                if (connectionStringParts.ContainsKey("Data Source"))
                    txtDataSource.Text = connectionStringParts["Data Source"];
                if (connectionStringParts.ContainsKey("Initial Catalog"))
                    txtInitialCatalog.Text = connectionStringParts["Initial Catalog"];
                if (connectionStringParts.ContainsKey("User ID"))
                    txtUserID.Text = connectionStringParts["User ID"];
                if (connectionStringParts.ContainsKey("Password"))
                    txtPassword.Text = connectionStringParts["Password"];
                if (connectionStringParts.ContainsKey("Encrypt"))
                    chkEncrypt.Checked = bool.Parse(connectionStringParts["Encrypt"]);
                if (connectionStringParts.ContainsKey("TrustServerCertificate"))
                    chkTrustServerCertificate.Checked = bool.Parse(connectionStringParts["TrustServerCertificate"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading current configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveCurrentConfiguration();

            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionString = $"Data Source={txtDataSource.Text};Initial Catalog={txtInitialCatalog.Text};User ID={txtUserID.Text};Password={txtPassword.Text};Encrypt={chkEncrypt.Checked};TrustServerCertificate={chkTrustServerCertificate.Checked};";

                config.ConnectionStrings.ConnectionStrings["Program.Properties.Settings.WarehouseConnectionString"].ConnectionString = connectionString;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("Configuration saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadSelectedConfiguration();
        }

        private void LoadSelectedConfiguration()
        {
            var selectedConfig = cmbConfigurations.SelectedItem?.ToString();
            if (selectedConfig == null)
            {
                MessageBox.Show("Please select a configuration to load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var doc = XDocument.Load(ConfigFilePath);
            var configs = doc.Element("Configurations").Elements("Configuration");

            foreach (var config in configs)
            {
                var configName = config.Element("Nickname")?.Value ?? $"{config.Element("DataSource").Value} - {config.Element("InitialCatalog").Value}";
                if (configName == selectedConfig)
                {
                    txtDataSource.Text = config.Element("DataSource").Value;
                    txtInitialCatalog.Text = config.Element("InitialCatalog").Value;
                    txtUserID.Text = config.Element("UserID").Value;
                    txtPassword.Text = config.Element("Password").Value;
                    txtNickname.Text = config.Element("Nickname")?.Value ?? string.Empty;
                    chkEncrypt.Checked = config.Element("Encrypt") != null ? bool.Parse(config.Element("Encrypt").Value) : false;
                    chkTrustServerCertificate.Checked = config.Element("TrustServerCertificate") != null ? bool.Parse(config.Element("TrustServerCertificate").Value) : false;
                    break;
                }
            }
        }

        private void SaveCurrentConfiguration()
        {
            var doc = XDocument.Load(ConfigFilePath);
            var configs = doc.Element("Configurations");

            var newConfig = new XElement("Configuration",
                new XElement("DataSource", txtDataSource.Text),
                new XElement("InitialCatalog", txtInitialCatalog.Text),
                new XElement("UserID", txtUserID.Text),
                new XElement("Password", txtPassword.Text),
                new XElement("Nickname", txtNickname.Text),
                new XElement("Encrypt", chkEncrypt.Checked),
                new XElement("TrustServerCertificate", chkTrustServerCertificate.Checked));

            configs.Add(newConfig);
            doc.Save(ConfigFilePath);

            LoadConfigurations();
        }

        private void LoadConfigurations()
        {
            if (!System.IO.File.Exists(ConfigFilePath))
            {
                var document = new XDocument(new XElement("Configurations"));
                document.Save(ConfigFilePath);
            }

            var doc = XDocument.Load(ConfigFilePath);
            var configs = doc.Element("Configurations").Elements("Configuration");

            cmbConfigurations.Items.Clear();

            foreach (var config in configs)
            {
                var configName = config.Element("Nickname")?.Value ?? $"{config.Element("DataSource").Value} - {config.Element("InitialCatalog").Value}";
                cmbConfigurations.Items.Add(configName);
            }
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            var connectionString = $"Data Source={txtDataSource.Text};Initial Catalog={txtInitialCatalog.Text};User ID={txtUserID.Text};Password={txtPassword.Text};Encrypt={chkEncrypt.Checked};TrustServerCertificate={chkTrustServerCertificate.Checked};";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    MessageBox.Show("Connection successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedConfig = cmbConfigurations.SelectedItem?.ToString();
            if (selectedConfig == null)
            {
                MessageBox.Show("Please select a configuration to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var doc = XDocument.Load(ConfigFilePath);
            var configs = doc.Element("Configurations").Elements("Configuration").ToList();

            var configToDelete = configs.FirstOrDefault(config =>
                (config.Element("Nickname")?.Value ?? $"{config.Element("DataSource").Value} - {config.Element("InitialCatalog").Value}") == selectedConfig);

            if (configToDelete != null)
            {
                configToDelete.Remove();
                doc.Save(ConfigFilePath);
                LoadConfigurations();
                MessageBox.Show("Configuration deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Configuration not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbConfigurations_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedConfiguration();
        }
    }
}