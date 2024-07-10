using System;
using Num2Wrd;
using Program.entity.controllar.AssetControllarTableAdapters;
using Program.entity.controllar.BankControllarTableAdapters;
using Program.entity.controllar.BondTableAdapters;
using Program.entity.controllar.BoxControllarTableAdapters;
using Program.entity.controllar.CustomerControllarTableAdapters;
using Program.entity.controllar.LiabilityControllarTableAdapters;
using Program.entity.controllar.PaperPayControllarTableAdapters;
using Program.entity.controllar.PaperReceiveControllarTableAdapters;
using Program.entity.controllar.SupplierControllarTableAdapters;

namespace Program.entity.controllar
{
    internal class BondControllar
    {
        public int indexValue;
        public double balance;
        public string balanceText;
        public string bondFrom;
        public string bondTo;
        public string comment = "";
        public DateTime date;
        public int referanceFrom;//من
        public string tableFrom;
        public int referanceTo;//إلى
        public string tableTo;
        private NumberToEnglish nte = new NumberToEnglish();

        public String SaveBonds()
        {
            date = DateTime.Now;
            string errorMessageDebit = "";
            string errorMessageCredit = "";

            //من
            string[] valueDebit = bondFrom.Split('.');
            tableFrom = valueDebit[0];
            Console.WriteLine("table=" + tableFrom + "  id=" + referanceFrom);
            if (balance > 0)
            {
                switch (tableFrom)
                {
                    case "زبون":
                        referanceFrom = Convert.ToInt32(valueDebit[2]);
                        errorMessageDebit = SaveCustomerBonds("from");
                        break;

                    case "سند قبض":
                        referanceFrom = Convert.ToInt32(valueDebit[2]);
                        errorMessageDebit = SavePaperReceivedBonds("from");
                        break;

                    case "صندوق":
                        referanceFrom = Convert.ToInt32(valueDebit[2]);
                        errorMessageDebit = SaveBoxBonds("from");
                        break;

                    case "مصرف":
                        referanceFrom = Convert.ToInt32(valueDebit[2]);
                        errorMessageDebit = SaveBankBonds("from");
                        break;

                    case "أصل":
                        referanceFrom = Convert.ToInt32(valueDebit[2]);
                        errorMessageDebit = SaveAssetBonds("from");
                        break;

                    case "مورد":
                        referanceFrom = Convert.ToInt32(valueDebit[2]);
                        errorMessageDebit = SaveSupplierBonds("from");
                        break;

                    case "إلتزام":
                        referanceFrom = Convert.ToInt32(valueDebit[2]);
                        errorMessageDebit = SaveLiablitityBonds("from");
                        break;

                    case "سند دفع":
                        referanceFrom = Convert.ToInt32(valueDebit[2]);
                        errorMessageDebit = SavePaperPayBonds("from");
                        break;
                }

                //إلى
                string[] valueCredit = bondTo.Split('.');
                tableTo = valueCredit[0];
                Console.WriteLine("table=" + tableTo + "  id=" + referanceTo);
                switch (tableTo)
                {
                    case "زبون":
                        referanceTo = Convert.ToInt32(valueCredit[2]);
                        errorMessageCredit = SaveCustomerBonds("to");
                        break;

                    case "سند قبض":
                        referanceTo = Convert.ToInt32(valueCredit[2]);
                        errorMessageCredit = SavePaperReceivedBonds("to");
                        break;

                    case "صندوق":
                        referanceTo = Convert.ToInt32(valueCredit[2]);
                        errorMessageCredit = SaveBoxBonds("to");
                        break;

                    case "مصرف":
                        referanceTo = Convert.ToInt32(valueCredit[2]);
                        errorMessageCredit = SaveBankBonds("to");
                        break;

                    case "أصل":
                        referanceTo = Convert.ToInt32(valueCredit[2]);
                        errorMessageCredit = SaveAssetBonds("to");
                        break;

                    case "مورد":
                        referanceTo = Convert.ToInt32(valueCredit[2]);
                        errorMessageCredit = SaveSupplierBonds("to");
                        break;

                    case "إلتزام":
                        referanceTo = Convert.ToInt32(valueCredit[2]);
                        errorMessageCredit = SaveLiablitityBonds("to");
                        break;

                    case "سند دفع":
                        referanceTo = Convert.ToInt32(valueCredit[2]);
                        errorMessageCredit = SavePaperPayBonds("to");
                        break;
                }

                bondsTableAdapter bta = new bondsTableAdapter();
                bta.Insert(balance, balanceText, bondFrom, bondTo, comment, date, "true");
            }
            return "Debit:" + errorMessageDebit + "-Credit:" + errorMessageCredit;
        }

        private string SaveLiablitityBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            liabilityTableAdapter lta = new liabilityTableAdapter();
            LiabilityControllar.liabilityDataTable ldt = lta.getLiabilityById(referance);
            LiabilityControllar.liabilityRow lr = ldt[0];
            if (direction == "from")
            {
                liability_debitTableAdapter ldta = new liability_debitTableAdapter();
                ldta.Insert(balance, balanceText, bondTo, comment, date, referance);
                //
                lr["الرصيد"] = Convert.ToInt32(lr["الرصيد"]) - balance;
                lr["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(lr["الرصيد"]));
                //update Customer Row
                lta.Update(lr);
            }
            if (direction == "to")
            {
                liability_creditTableAdapter ldta = new liability_creditTableAdapter();
                ldta.Insert(balance, balanceText, bondFrom, comment, date, referance);
                //
                lr["الرصيد"] = Convert.ToInt32(lr["الرصيد"]) + balance;
                lr["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(lr["الرصيد"]));
                //update Customer Row
                lta.Update(lr);
            }
            return "";
        }

        //الأصول
        private string SavePaperReceivedBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
            PaperReceiveControllar.paper_receiveDataTable prdt = prta.PaperReceiveById(referance);
            PaperReceiveControllar.paper_receiveRow prr = prdt[0];
            if (direction == "from")
            {
                paper_receive_debitTableAdapter adta = new paper_receive_debitTableAdapter();
                adta.Insert(balance, balanceText, bondTo, comment, date, referance);
                //
                prr["الرصيد"] = Convert.ToInt32(prr["الرصيد"]) + balance;
                prr["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(prr["الرصيد"]));
                //update Customer Row
                prta.Update(prr);
            }
            if (direction == "to")
            {
                paper_receive_creditTableAdapter acta = new paper_receive_creditTableAdapter();
                acta.Insert(balance, balanceText, bondFrom, comment, date, referance);
                //
                prr["الرصيد"] = Convert.ToInt32(prr["الرصيد"]) - balance;
                prr["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(prr["الرصيد"]));

                if (Convert.ToInt32(prr["الرصيد"]) < balance)
                {
                    message = "إن رصيد الأصل غير كافي";
                    //update Customer Row
                    prta.Update(prr);
                }
                else
                {
                    //update Customer Row
                    prta.Update(prr);
                }
            }
            return message;
        }

        private string SaveAssetBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            assetTableAdapter ata = new assetTableAdapter();
            AssetControllar.assetDataTable adt = ata.getAssetById(referance);
            AssetControllar.assetRow ar = adt[0];
            if (direction == "from")
            {
                asset_debitTableAdapter adta = new asset_debitTableAdapter();
                adta.Insert(balance, balanceText, bondTo, comment, date, referance);
                //
                ar["الرصيد"] = Convert.ToInt32(ar["الرصيد"]) + balance;
                ar["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(ar["الرصيد"]));
                //update Customer Row
                ata.Update(ar);
            }
            if (direction == "to")
            {
                asset_creditTableAdapter acta = new asset_creditTableAdapter();
                acta.Insert(balance, balanceText, bondFrom, comment, date, referance);
                //
                ar["الرصيد"] = Convert.ToInt32(ar["الرصيد"]) - balance;
                ar["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(ar["الرصيد"]));

                if (Convert.ToInt32(ar["الرصيد"]) < balance)
                {
                    message = "إن رصيد الأصل غير كافي";
                    //update Customer Row
                    ata.Update(ar);
                }
                else
                {
                    //update Customer Row
                    ata.Update(ar);
                }
            }
            return message;
        }

        //زبائن
        public string SaveCustomerBonds(string direction)//from or to
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            customerTableAdapter cta = new customerTableAdapter();
            CustomerControllar.customerDataTable cdt = cta.getCustomerById(referance);
            CustomerControllar.customerRow cr = cdt[0];
            if (direction == "from")
            {
                customer_debitTableAdapter cdta = new customer_debitTableAdapter();
                cdta.Insert(balance, balanceText, bondTo, comment, date, referance);
                //
                cr["الرصيد"] = Convert.ToInt32(cr["الرصيد"]) + balance;
                cr["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(cr["الرصيد"]));
                //update Customer Row
                cta.Update(cr);
            }
            if (direction == "to")
            {
                customer_creditTableAdapter ccta = new customer_creditTableAdapter();
                ccta.Insert(balance, balanceText, bondFrom, comment, date, referance);
                //
                cr["الرصيد"] = Convert.ToInt32(cr["الرصيد"]) - balance;
                cr["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(cr["الرصيد"]));

                if (Convert.ToInt32(cr["الرصيد"]) < balance)
                {
                    message = "إن رصيد الزبون غير كافي";
                    //update Customer Row
                    cta.Update(cr);
                }
                else
                {
                    //update Customer Row
                    cta.Update(cr);
                }
            }
            return message;
        }

        //الصندق
        public string SaveBoxBonds(string direction)//from or to
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            boxTableAdapter bta = new boxTableAdapter();
            BoxControllar.boxDataTable cdt = bta.GetBoxById(referance);
            BoxControllar.boxRow br = cdt[0];

            if (direction == "from")
            {
                box_debitTableAdapter cdta = new box_debitTableAdapter();
                cdta.Insert(balance, balanceText, bondTo, comment, date, referance);

                //
                br["الرصيد"] = Convert.ToInt32(br["الرصيد"]) + balance;
                br["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(br["الرصيد"]));
                //update Customer Row
                bta.Update(br);
            }
            if (direction == "to")
            {
                box_creditTableAdapter cdta = new box_creditTableAdapter();
                cdta.Insert(balance, balanceText, bondFrom, comment, date, referance);
                //
                br["الرصيد"] = Convert.ToInt32(br["الرصيد"]) - balance;
                br["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(br["الرصيد"]));
                //update Customer Row
                if (Convert.ToInt32(br["الرصيد"]) < balance)
                {
                    bta.Update(br);
                    message = "إن رصيد الصندوق غير كافي";
                }
                else
                {
                    bta.Update(br);
                }
            }
            return message;
        }

        //البنك
        public string SaveBankBonds(string direction)//from or to
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            bank_accountTableAdapter bata = new bank_accountTableAdapter();
            BankControllar.bank_accountDataTable cdt = bata.getBankAccountingId(referance);
            BankControllar.bank_accountRow br = cdt[0];

            if (direction == "from")
            {
                bank_debitTableAdapter cdta = new bank_debitTableAdapter();
                cdta.Insert(balance, balanceText, bondTo, comment, date, referance);
                //
                br["الرصيد"] = Convert.ToInt32(br["الرصيد"]) + balance;
                br["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(br["الرصيد"]));
                //update Customer Row
                bata.Update(br);
            }
            if (direction == "to")
            {
                bank_creditTableAdapter cdta = new bank_creditTableAdapter();
                cdta.Insert(balance, balanceText, bondFrom, comment, date, referance);
                //
                br["الرصيد"] = Convert.ToInt32(br["الرصيد"]) - balance;
                br["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(br["الرصيد"]));
                //update Customer Row
                if (Convert.ToInt32(br["الرصيد"]) < balance)
                {
                    bata.Update(br);
                    message = "إن رصيد البنك غير كافي";
                }
                else
                {
                    bata.Update(br);
                }
            }
            return message;
        }

        //التزامات
        //
        //موردين
        public string SaveSupplierBonds(string direction)//from or to
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            supplierTableAdapter sta = new supplierTableAdapter();
            SupplierControllar.supplierDataTable sdt = sta.getSupplierById(referance);
            SupplierControllar.supplierRow sr = sdt[0];
            if (direction == "from")
            {
                supplier_debitTableAdapter sdta = new supplier_debitTableAdapter();
                sdta.Insert(balance, balanceText, bondTo, comment, date, referance);
                //
                sr["الرصيد"] = Convert.ToInt32(sr["الرصيد"]) - balance;
                sr["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(sr["الرصيد"]));
                //update Customer Row
                sta.Update(sr);
            }
            if (direction == "to")
            {
                supplier_creditTableAdapter sdta = new supplier_creditTableAdapter();
                sdta.Insert(balance, balanceText, bondFrom, comment, date, referance);
                //
                sr["الرصيد"] = Convert.ToInt32(sr["الرصيد"]) + balance;
                sr["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(sr["الرصيد"]));
                //update Customer Row
                sta.Update(sr);
            }
            return "";
        }

        private string SavePaperPayBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            paper_payTableAdapter ppta = new paper_payTableAdapter();
            PaperPayControllar.paper_payDataTable ppdt = ppta.getPaperPayById(referance);
            PaperPayControllar.paper_payRow ppr = ppdt[0];
            if (direction == "from")
            {
                paper_pay_debitTableAdapter ppdta = new paper_pay_debitTableAdapter();
                ppdta.Insert(balance, balanceText, bondTo, comment, date, referance);
                //
                ppr["الرصيد"] = Convert.ToInt32(ppr["الرصيد"]) - balance;
                ppr["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(ppr["الرصيد"]));
                //update Customer Row
                ppta.Update(ppr);
            }
            if (direction == "to")
            {
                paper_pay_creditTableAdapter ppcta = new paper_pay_creditTableAdapter();
                ppcta.Insert(balance, balanceText, bondFrom, comment, date, referance);
                //
                ppr["الرصيد"] = Convert.ToInt32(ppr["الرصيد"]) + balance;
                ppr["الرصيد_كتابة"] = nte.changeNumericToWords(Convert.ToDouble(ppr["الرصيد"]));
                //update Customer Row
                ppta.Update(ppr);
            }
            return "";
        }

        //chech the bound if there is any error
        public String[] CheckBonds(string how)//from or to or both
        {
            date = DateTime.Now;
            string errorMessageDebit = "";
            string errorMessageCredit = "";
            string[] message = new string[2];
            try
            {
                //من
                if (how == "from" || how == "both")
                {
                    string[] valueDebit = bondFrom.Split('.');
                    tableFrom = valueDebit[0];
                    Console.WriteLine("table=" + tableFrom + "  id=" + referanceFrom);
                    switch (tableFrom)
                    {
                        case "زبون":
                            referanceFrom = Convert.ToInt32(valueDebit[2]);
                            errorMessageDebit = CheckCustomerBonds("from");
                            break;

                        case "سند قبض":
                            referanceFrom = Convert.ToInt32(valueDebit[2]);
                            errorMessageDebit = CheckPaperReceivedBonds("from");
                            break;

                        case "مورد":
                            referanceFrom = Convert.ToInt32(valueDebit[2]);
                            errorMessageDebit = CheckSupplierBonds("from");

                            break;

                        case "صندوق":
                            referanceFrom = Convert.ToInt32(valueDebit[2]);
                            errorMessageDebit = CheckBoxBonds("from");
                            break;

                        case "مصرف":
                            referanceFrom = Convert.ToInt32(valueDebit[2]);
                            errorMessageDebit = CheckBankBonds("from");
                            break;

                        case "أصل":
                            referanceFrom = Convert.ToInt32(valueDebit[2]);
                            errorMessageDebit = CheckAssetBonds("from");
                            break;

                        case "سند دفع":
                            referanceFrom = Convert.ToInt32(valueDebit[2]);
                            errorMessageDebit = CheckPaperPayBonds("from");
                            break;

                        case "إلتزام":
                            referanceFrom = Convert.ToInt32(valueDebit[2]);
                            errorMessageDebit = CheckLiabilityBonds("from");
                            break;
                    }
                }
                //إلى
                if (how == "to" || how == "both")
                {
                    string[] valueCredit = bondTo.Split('.');
                    tableTo = valueCredit[0];
                    Console.WriteLine("table=" + tableTo + "  id=" + referanceTo);
                    switch (tableTo)
                    {
                        case "زبون":
                            referanceTo = Convert.ToInt32(valueCredit[2]);
                            errorMessageCredit = CheckCustomerBonds("to");
                            break;

                        case "سند قبض":
                            referanceTo = Convert.ToInt32(valueCredit[2]);
                            errorMessageCredit = CheckPaperReceivedBonds("to");
                            break;

                        case "مورد":
                            referanceTo = Convert.ToInt32(valueCredit[2]);
                            errorMessageCredit = CheckSupplierBonds("to");
                            break;

                        case "صندوق":
                            referanceTo = Convert.ToInt32(valueCredit[2]);
                            errorMessageCredit = CheckBoxBonds("to");
                            break;

                        case "مصرف":
                            referanceTo = Convert.ToInt32(valueCredit[2]);
                            errorMessageCredit = CheckBankBonds("to");
                            break;

                        case "أصل":
                            referanceTo = Convert.ToInt32(valueCredit[2]);
                            errorMessageCredit = CheckAssetBonds("to");
                            break;

                        case "سند دفع":
                            referanceTo = Convert.ToInt32(valueCredit[2]);
                            errorMessageCredit = CheckPaperPayBonds("to");
                            break;

                        case "إلتزام":
                            referanceTo = Convert.ToInt32(valueCredit[2]);
                            errorMessageCredit = CheckLiabilityBonds("to");
                            break;
                    }
                }
                Console.WriteLine("table=" + tableFrom + "  id=" + referanceFrom);
                message[0] = errorMessageDebit;
                message[1] = errorMessageCredit;
            }
            catch (Exception ex)
            {
                Console.WriteLine("error :::: " + ex.Message);
            }
            return message;
        }

        private string CheckLiabilityBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            liabilityTableAdapter lta = new liabilityTableAdapter();
            LiabilityControllar.liabilityDataTable ldt = lta.getLiabilityById(referance);
            LiabilityControllar.liabilityRow lr = ldt[0];
            if (direction == "from")
            {
                Console.WriteLine("row 458");
                if (Convert.ToInt32(lr["الرصيد"]) < balance)
                {
                    message = "إن مبلغ سند الدفع المستحق =" + lr["الرصيد"] + "     ";
                }
                else
                {
                }
            }
            if (direction == "to")
            {
                Console.WriteLine("");
            }
            return message;
        }

        private string CheckPaperPayBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            paper_payTableAdapter ppta = new paper_payTableAdapter();
            PaperPayControllar.paper_payDataTable ppdt = ppta.getPaperPayById(referance);
            PaperPayControllar.paper_payRow ppr = ppdt[0];
            if (direction == "from")
            {
                Console.WriteLine("row 458");
                if (Convert.ToInt32(ppr["الرصيد"]) < balance)
                {
                    message = "إن مبلغ سند الدفع المستحق =" + ppr["الرصيد"] + "     ";
                }
                else
                {
                }
            }
            if (direction == "to")
            {
                Console.WriteLine("");
            }
            return message;
        }

        private string CheckPaperReceivedBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            paper_receiveTableAdapter prta = new paper_receiveTableAdapter();
            PaperReceiveControllar.paper_receiveDataTable prdt = prta.PaperReceiveById(referance);
            PaperReceiveControllar.paper_receiveRow prr = prdt[0];

            if (direction == "from")
            {
            }
            if (direction == "to")
            {
                if (Convert.ToInt32(prr["الرصيد"]) < balance)
                {
                    Console.WriteLine("row 694");
                    message = "إن مبلغ سند القبض المستحق =" + prr["الرصيد"] + "     ";
                }
                else
                {
                }
            }
            return message;
        }

        private string CheckAssetBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            assetTableAdapter ata = new assetTableAdapter();
            AssetControllar.assetDataTable adt = ata.getAssetById(referance);
            AssetControllar.assetRow ar = adt[0];

            if (direction == "from")
            {
            }
            if (direction == "to")
            {
                if (Convert.ToInt32(ar["الرصيد"]) < balance)
                {
                    message = "إن رصيد الأصل غير كافي=" + ar["الرصيد"] + "     ";
                }
                else
                {
                }
            }
            return message;
        }

        private string CheckBankBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            bank_accountTableAdapter bata = new bank_accountTableAdapter();
            BankControllar.bank_accountDataTable cdt = bata.getBankAccountingId(referance);
            BankControllar.bank_accountRow br = cdt[0];

            if (direction == "from")
            {
            }
            if (direction == "to")
            {
                if (Convert.ToInt32(br["الرصيد"]) < balance)
                {
                    message = "إن رصيد البنك غير كافي=" + br["الرصيد"] + "     ";
                }
                else
                {
                }
            }
            return message;
        }

        private string CheckBoxBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            boxTableAdapter bta = new boxTableAdapter();
            BoxControllar.boxDataTable cdt = bta.GetBoxById(referance);
            BoxControllar.boxRow br = cdt[0];

            if (direction == "from")
            {
            }
            if (direction == "to")
            {
                if (Convert.ToInt32(br["الرصيد"]) < balance)
                {
                    message = "إن رصيد الصندوق غير كافي=" + br["الرصيد"] + "     ";
                }
                else
                {
                }
            }
            return message;
        }

        private string CheckCustomerBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            customerTableAdapter cta = new customerTableAdapter();
            CustomerControllar.customerDataTable cdt = cta.getCustomerById(referance);
            CustomerControllar.customerRow cr = cdt[0];
            if (direction == "from")
            {
            }
            if (direction == "to")
            {
                if (Convert.ToInt32(cr["الرصيد"]) < balance)
                {
                    message = "إن المبلغ المدفوع أكبر من رصيد الزبون =" + cr["الرصيد"] + "     ";
                }
                else
                {
                }
            }
            return message;
        }

        private string CheckSupplierBonds(string direction)
        {
            int referance = 0;
            if (direction == "to")
            {
                referance = referanceTo;
            }
            if (direction == "from")
            {
                referance = referanceFrom;
            }
            string message = "";
            supplierTableAdapter sta = new supplierTableAdapter();
            SupplierControllar.supplierDataTable sdt = sta.getSupplierById(referance);
            SupplierControllar.supplierRow sr = sdt[0];
            if (direction == "from")
            {
                Console.WriteLine("row 458");
                if (Convert.ToInt32(sr["الرصيد"]) < balance)
                {
                    message = "لا يمكنك دفع مبلغ اكبر من رصيد المورد= " + sr["الرصيد"] + "     ";
                }
                else
                {
                }
            }
            if (direction == "to")
            {
                Console.WriteLine("row 469");
            }
            return message;
        }
    }
}