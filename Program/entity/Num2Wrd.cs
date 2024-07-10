using System;

namespace Num2Wrd
{
    public class NumberToEnglish
    {
        public static double number1 = 0;

        public String changeNumericToWords(double numb)
        {
            String num = numb.ToString();
            number1 = numb;
            return changeToWords(num, false);
        }

        public String changeCurrencyToWords(String numb)
        {
            return changeToWords(numb, true);
        }

        public String changeNumericToWords(String numb)
        {
            return changeToWords(numb, false);
        }

        public String changeCurrencyToWords(double numb)
        {
            number1 = numb;
            return changeToWords(numb.ToString(), true);
        }

        private String changeToWords(String numb, bool isCurrency)
        {
            String val = "", wholeNo = numb, points = "", andStr = "", pointStr = "";
            String endStr = (isCurrency) ? ("·Ì—… ”Ê—Ì… ·«€Ì—") : ("");
            try
            {
                int decimalPlace = numb.IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = numb.Substring(0, decimalPlace);
                    points = numb.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = (isCurrency) ? ("Ê") : ("›«’·…");// just to separate whole numbers from points/Rupees
                        endStr = (isCurrency) ? ("·Ì—… ”Ê—Ì…" + endStr) : ("");
                        pointStr = translateRupees(points);
                    }
                }
                val = String.Format("{0} {1}{2} {3}", translateWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
            }
            catch
            {
                ;
            }
            return val;
        }

        private String translateWholeNumber(String number)
        {
            string word = "";
            try
            {
                bool beginsZero = false;//tests for 0XX
                bool isDone = false;//test if already translated
                double dblAmt = (Convert.ToDouble(number));
                //if ((dblAmt > 0) && number.StartsWith("0"))

                if (dblAmt > 0)
                {//test for zero or digit zero in a nuemric
                    beginsZero = number.StartsWith("0");
                    number = Convert.ToInt32(number).ToString();
                    int numDigits = number.Length;
                    if (numDigits >= 3)
                    {
                        number1 = Convert.ToDouble(number);
                        Console.WriteLine("number1 :" + number);
                    }

                    int pos = 0;//store digit grouping
                    String place = "";//digit grouping name:hundres,thousand,etc...

                    switch (numDigits)
                    {
                        case 1://ones' range
                            if ((number1 > 99 && number1 < 300) || number1 >= 1000 && number1 < 3000)
                            {
                                number = number + "00";
                                word = ones(number);
                            }
                            else
                            {
                                word = ones(number);
                            }
                            Console.WriteLine("ones :" + "word : " + word + " num :" + number);
                            isDone = true;
                            break;

                        case 2://tens' range
                            word = tens(number);
                            Console.WriteLine("tens :" + "word : " + word + " num :" + number);
                            isDone = true;
                            break;

                        case 3://hundreds' range
                            pos = (numDigits % 3) + 1;

                            if (number1 >= 200 && number1 < 300)
                            {
                                place = " „∆ «‰ ";
                            }
                            else
                            {
                                place = " „∆… ";
                            }

                            break;

                        case 4://thousands' range
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;

                            if (number1 <= 10000)
                            {
                                place = "  «·«› ";
                            }
                            if (number1 > 10000 || number1 < 2000)
                            {
                                place = "  √·› ";
                            }
                            if (number1 >= 2000 && number1 < 3000)
                            {
                                place = "  √·›«‰ ";
                            }

                            break;

                        case 7://millions' range
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " „·«Ì‰  ";
                            break;

                        case 10://Billions's range
                            pos = (numDigits % 10) + 1;
                            place = " „·Ì«—  ";
                            break;
                        //add extra case options for anything above Billion...
                        default:
                            isDone = true;
                            break;
                    }
                    //     word.PadRight(word.Length);
                    if (!isDone)
                    {//if transalation is not done, continue...(Recursion comes in now!!)
                        word = translateWholeNumber(number.Substring(0, pos)) + place + " Ê " + translateWholeNumber(number.Substring(pos));
                        //check for trailing zeros

                        if (beginsZero) word = " Ê " + word.Trim();
                    }
                    //ignore digit grouping names
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch
            {
                ;
            }
            return word.Trim();
        }

        private String tens(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = null;
            switch (digt)
            {
                case 10:
                    name = "⁄‘—…";
                    break;

                case 11:
                    name = "«Õœ ⁄‘—";
                    break;

                case 12:
                    name = "«À‰« ⁄‘—";
                    break;

                case 13:
                    name = "À·«À ⁄‘— ";
                    break;

                case 14:
                    name = "«—»⁄… ⁄‘—";
                    break;

                case 15:
                    name = "Œ„”… ⁄‘—";
                    break;

                case 16:
                    name = "” … ⁄‘—…";
                    break;

                case 17:
                    name = "”»⁄… ⁄‘—…";
                    break;

                case 18:
                    name = "À„«‰Ì… ⁄‘—…";
                    break;

                case 19:
                    name = " ”⁄… ⁄‘—…";
                    break;

                case 20:
                    name = " ⁄‘—Ê‰";
                    break;

                case 30:
                    name = "  À·«ÀÊ‰";
                    break;

                case 40:
                    name = " «—»⁄Ê‰";
                    break;

                case 50:
                    name = " Œ„”Ê‰";
                    break;

                case 60:
                    name = " ” Ê‰";
                    break;

                case 70:
                    name = " ”»⁄Ê‰";
                    break;

                case 80:
                    name = " À„«‰Ê‰";
                    break;

                case 90:
                    name = "  ”⁄Ê‰";
                    break;

                default:
                    if (digt > 0)
                    {
                        Console.WriteLine("digt :" + digt);
                        if (digt > 99)
                        {
                            name = ones(digit.Substring(1) + "00") + " " + tens(digit.Substring(0, 1) + "0");
                        }
                        else
                        {
                            name = ones(digit.Substring(1)) + " " + tens(digit.Substring(0, 1) + "0");
                        }
                    }
                    break;
            }
            return name;
        }

        private String ones(String digit)
        {
            int digt = Convert.ToInt32(digit);
            String name = "";
            switch (digt)
            {
                case 0:
                    name = " ";
                    break;

                case 1:
                    name = "Ê«Õœ";
                    break;

                case 2:
                    name = "«À‰«‰";
                    break;

                case 3:
                    name = "À·«À";
                    break;

                case 4:
                    name = "√—»⁄…";
                    break;

                case 5:
                    name = "Œ„”…";
                    break;

                case 6:
                    name = "” …";
                    break;

                case 7:
                    name = "”»⁄…";
                    break;

                case 8:
                    name = "À„«‰Ì…";
                    break;

                case 9:
                    name = " ”⁄…";
                    break;

                case 100:
                    name = " ";
                    break;

                case 200:
                    name = " ";
                    break;
            }
            return name;
        }

        private String translateRupees(String Rupees)
        {
            String cts = "", digit = "", engOne = "";
            for (int i = 0; i < Rupees.Length; i++)
            {
                digit = Rupees[i].ToString();
                if (digit.Equals("0"))
                {
                    engOne = "’›—";
                }
                else
                {
                    engOne = ones(digit);
                }
                cts += " " + engOne;
            }
            return cts;
        }
    }
}