using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using Program.entity.controllar.MaterialControllarTableAdapters;
using Program.entity.controllar;
using Program.entity;

namespace Program.entityForm.File
{
    public partial class ImportData : Form
    {

        // to OleDb connection
        public OleDbConnection conn;
        public OleDbCommand command;
        public OleDbDataReader reader;
        public OleDbDataAdapter adapter;
        //public OleDbMetaDataCollectionNames metaData ;
        public DataTable table;

        //  public SqlCommandBuilder commandBuilder;
        private string ConnectionStringOleDb = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
        private string ConnectionStringOdbc = "Dsn=";
        private string Connection = "";

        public ImportData()
        {
            InitializeComponent();
        }

        private void bTestConnection_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (ComboBoxConnectionType.Text == "LINK")
            {
                openFileDialogAccess.ShowDialog();
                fileName = openFileDialogAccess.FileName;
                txtDatabaseName.Text =
                Connection = ConnectionStringOleDb + fileName;
                Console.WriteLine(ConnectionStringOleDb);
                TestConnectionOleDb();
            }
            if (ComboBoxConnectionType.Text == "ODBC")
            {
                fileName = txtDatabaseName.Text;
                Connection = ConnectionStringOdbc + fileName;
                Console.WriteLine(ConnectionStringOdbc);
                TestConnectionOleDb();
            }
        }

        public void TestConnectionOleDb()
        {
            try
            {
                conn = new OleDbConnection(Connection);
                conn.Open();
                MessageBox.Show("Connection Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Console.WriteLine("connect Sueccessfully........");
                DataTable table = conn.GetSchema("Tables");
                // Display the contents of the table.
                DisplayData(table);

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayData(DataTable table)
        {
            ComboBoxTable.Items.Clear();
            foreach (System.Data.DataRow row in table.Rows)
            {
                foreach (System.Data.DataColumn col in table.Columns)
                {
                    if (col.ColumnName == "TABLE_NAME")
                    {
                        ComboBoxTable.Items.Add(row["TABLE_NAME"].ToString());
                        Console.WriteLine("{0} = {1}", col.ColumnName, row["TABLE_NAME"]);
                    }
                }
                Console.WriteLine("============================");
            }
        }

        private void bTableRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                string strCommand = "select * from " + ComboBoxTable.Text.Trim();
                Console.WriteLine(strCommand);
                conn = new OleDbConnection(Connection);
                command = new OleDbCommand(strCommand, conn);
                conn.Open();
                adapter = new OleDbDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);

                conn.Close();
                dataGridViewTable.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bTransfareData_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new OleDbConnection(Connection);
                conn.Open();
                DataTable columns = conn.GetSchema("Columns");
                DisplayDataColumn(columns);
                MessageBox.Show("Column Of Table " + ComboBoxTable.Text + " Has Been add Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message" + ex.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayDataColumn(DataTable table)
        {
            ArrayList column = new ArrayList();
            foreach (System.Data.DataRow row in table.Rows)
            {
                if (row["TABLE_NAME"].ToString() == ComboBoxTable.Text)
                {
                    foreach (System.Data.DataColumn col in table.Columns)
                    {
                        if (col.ColumnName == "COLUMN_NAME")
                        {
                            column.Add(row["COLUMN_NAME"].ToString());
                            Console.WriteLine("{0} = {1}", col.ColumnName, row["COLUMN_NAME"]);
                        }
                    }
                }
                Console.WriteLine("...============================...");
            }

            if (tabControl1.SelectedIndex == 0)
            {
                comboBoxId.Items.Clear();
                comboBoxName.Items.Clear();
                comboBoxPlace.Items.Clear();
                comboBoxUnit.Items.Clear();
                comboBoxPrice.Items.Clear();
                comboBoxPriceBuy.Items.Clear();
                comboBoxPriceSale.Items.Clear();
                comboBoxQuantity.Items.Clear();
                comboBoxProducer.Items.Clear();
                comboBoxWarehouse.Items.Clear();
                comboBoxGroup.Items.Clear();

                comboBoxId.Items.AddRange(column.ToArray());
                comboBoxName.Items.AddRange(column.ToArray());
                comboBoxPlace.Items.AddRange(column.ToArray());
                comboBoxUnit.Items.AddRange(column.ToArray());
                comboBoxPrice.Items.AddRange(column.ToArray());
                comboBoxPriceBuy.Items.AddRange(column.ToArray());
                comboBoxPriceSale.Items.AddRange(column.ToArray());
                comboBoxQuantity.Items.AddRange(column.ToArray());
                comboBoxProducer.Items.AddRange(column.ToArray());
                comboBoxWarehouse.Items.AddRange(column.ToArray());
                comboBoxGroup.Items.AddRange(column.ToArray());
            }
        }

        private void bTransfare_Click(object sender, EventArgs e)
        {
            TransfareMaterial();
        }

        public void TransfareMaterial()
        {
           /* try
            {*/
                int rowNumber = 0;
                richTextBoxStatus.Clear();
                materialTableAdapter mta = new materialTableAdapter();
                material m = new material();

                ArrayList error = new ArrayList();

                string strCommand = "select * from " + ComboBoxTable.Text;
                conn = new OleDbConnection(Connection);
                command = new OleDbCommand(strCommand, conn);
                conn.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                   /* try
                    {*/
                        //      rowNumber++;
                        m.اسم_المادة = reader[comboBoxName.Text.ToString()].ToString();
                        m.تواجد_المادة = reader[comboBoxPlace.Text.ToString()].ToString();
                        m.الوحدة = reader[comboBoxUnit.Text.ToString()].ToString();

                        ///////////////////////////////////////////////
                        if (reader[comboBoxId.Text.ToString()].ToString() == "")
                        {
                            m.كود_المادة = "";
                        }
                        if (reader[comboBoxPrice.Text.ToString()].ToString() == "")
                        {
                            m.سعر = 0;
                        }
                        if (reader[comboBoxPriceSale.Text.ToString()].ToString() == "")
                        {
                            m.سعر_البيع = 0;
                        }
                        if (reader[comboBoxPriceBuy.Text.ToString()].ToString() == "")
                        {
                            m.سعر_الشراء = 0;
                        }
                        if (reader[comboBoxQuantity.Text.ToString()].ToString() == "")
                        {
                            m.كمية = 0;
                        }
                        /*if (reader[comboBoxProducer.Text.ToString()].ToString() == "")
                        {
                            m.الصانع = 0;
                        }
                        if (reader[comboBoxGroup.Text.ToString()].ToString() == "")
                        {
                            m.المجموعة = 0;
                        }
                        if (reader[comboBoxWarehouse.Text.ToString()].ToString() == "")
                        {
                            m.المستودع = 0;
                        }*/

                        // System.Type type = "".GetType();
                        ///////////////////////////////////////////
                        if (reader[comboBoxId.Text.ToString()].ToString() != "")
                        {
                            m.كود_المادة = Convert.ToString(reader[comboBoxId.Text.ToString()].ToString());
                        }
                        if (reader[comboBoxPrice.Text.ToString()].ToString() != "")
                        {
                            m.سعر = Convert.ToInt32(reader[comboBoxPrice.Text.ToString()].ToString());
                        }
                        if (reader[comboBoxPriceSale.Text.ToString()].ToString() != "")
                        {
                            m.سعر_البيع = Convert.ToInt32(reader[comboBoxPriceSale.Text.ToString()].ToString());
                        }
                        if (reader[comboBoxPriceSale.Text.ToString()].ToString() != "")
                        {
                            m.سعر_الشراء = Convert.ToInt32(reader[comboBoxPriceSale.Text.ToString()].ToString());
                        }
                        if (reader[comboBoxQuantity.Text.ToString()].ToString() != "")
                        {
                            m.كمية = Convert.ToInt32(reader[comboBoxQuantity.Text.ToString()].ToString());
                        }
                       /* if (reader[comboBoxProducer.Text.ToString()].ToString() != "")
                        {
                            m.الصانع = Convert.ToInt16(reader[comboBoxProducer.Text.ToString()].ToString());
                        }
                        if (reader[comboBoxGroup.Text.ToString()].ToString() != "")
                        {
                            m.المجموعة = Convert.ToInt16(reader[comboBoxGroup.Text.ToString()].ToString());
                        }
                        if (reader[comboBoxWarehouse.Text.ToString()].ToString() != "")
                        {
                            m.المستودع = Convert.ToInt32(reader[comboBoxWarehouse.Text.ToString()].ToString());
                        }
                    */
                        ///////////////////////////////////////////
                        
                            rowNumber++;
                            mta.Insert(m.اسم_المادة,
                                m.تواجد_المادة,
                                m.الوحدة,
                                m.كمية,
                                m.سعر,
                                "",
                                 0,
                                 0,
                                 "",
                                 0,
                                "",
                                "",
                                0,
                                0,
                                m.سعر_الشراء,
                                m.سعر_البيع,
                                m.كود_المادة ,
                                m.طريقة_حساب_الكلفة);
                            //   richTextBoxStatus.AppendText("row number :" + rowNumber + "  \n");

                            richTextBoxStatus.AppendText("row number :" + rowNumber + "  \n");
                            richTextBoxStatus.ScrollToCaret();

                  /*  }
                    catch (Exception ex)
                    {
                        Console.WriteLine("ERROR :::::: " + ex.Message);
                        richTextBoxStatus.AppendText("insert Has been fail  :" + rowNumber + "  " + ex.Message + "\n\n");
                        richTextBoxStatus.ScrollToCaret();
                        //  error.Add("error  material Number : " + m.id_);

                        //  MessageBox.Show("message : " + ex.Message +" material id : "+ m.id_ , "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/

                }
                MessageBox.Show("data has been transfare", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                richTextBoxStatus.AppendText("=================\n");
                richTextBoxStatus.AppendText(" row insert : " + rowNumber + " \n");
                // listBoxStatus.Items.AddRange(error.ToArray());
            /*}
            catch (Exception ex)
            {
                MessageBox.Show("عدل اسم الجدول بحيث لا توجد فراعات في الاسم");
            }*/
        }

    }
}
