/*
 * UnitTestDriver is the class 
 * which methods test the NameExtractor object's functionality.
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;



namespace NameExtractor
{
    class UnitTestDriver
    {
        //an object of tested class NameExtractor
        public NameExtractor NameExtractor1;

        public UnitTestDriver()
        {
           NameExtractor1 = new NameExtractor();
         

       }
       #region //helper functions controlling test results
       private String NotEqualsErrorMessage(String Expected, String Actual, ref String Msg)
        {
           if (Msg != "")
           {
               Msg =Msg+" : expected "+Expected + ", but was: " + Actual;
            }
            return Msg;
        }
        private String EqualsErrorMessage(String Expected, String Actual, ref String Msg)
        {
            if (Msg != "")
            {
                Msg = Msg + " : expected " + Expected + " and actual were: " + Actual;
            }
            return Msg;
        }
        private void CheckEquals(String Expected, String Actual, String Msg)
        {
                if (Expected != Actual)
                {
                    NotEqualsErrorMessage(Expected, Actual, ref Msg);
                    Exception exception = new Exception(Msg);
                    throw exception;
                }
        }
        private void CheckNotEquals(String Expected, String Actual, String Msg)
        {
            if (Expected == Actual)
            {
                NotEqualsErrorMessage(Expected, Actual, ref Msg);
                Exception exception = new Exception(Msg);
                throw exception;
            }
        }
       # endregion

        //tests
       //Busuness Rule 1
        public void Test1()
        {
            NameExtractor1.FullName = "Mr John Greench Brown, PhD";
            CheckEquals("Mr", NameExtractor1.Title, " Title is not correct");
            CheckEquals("John", NameExtractor1.FirstName, "First Name is not correct");
            CheckEquals("Greench", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Brown", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("PhD", NameExtractor1.Suffix, " Suffix is not correct");
        }
        //Busuness Rule 2
        public void Test2()
        {
            NameExtractor1.FullName = "John Brown";
            CheckEquals("", NameExtractor1.Title, " Title is not correct");
            CheckEquals("John", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Brown", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");
            NameExtractor1.FullName = "Mr.    John Brown";
            CheckEquals("Mr", NameExtractor1.Title, " Title is not correct");
            CheckEquals("John", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Brown", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");

            NameExtractor1.FullName = "John Brown, PhD";
            CheckEquals("John", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("Brown", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("PhD", NameExtractor1.Suffix, " Suffix is not correct");
            
        }

        //Busuness Rule 3
        public void Test3()
        {
            NameExtractor1.FullName = "John-Martin Brown";
            CheckEquals("", NameExtractor1.Title, " Title is not correct");
            CheckEquals("John-Martin", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Brown", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");

            NameExtractor1.FullName = "Mr.    John Brown-II";
            CheckEquals("Mr", NameExtractor1.Title, " Title is not correct");
            CheckEquals("John", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Brown-II", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");
        }
        //Business Rule 4
        public void Test4()
        {
            NameExtractor1.FullName = "Brown";
            CheckEquals("", NameExtractor1.Title, " Title is not correct");
            CheckEquals("", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Brown", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");
            NameExtractor1.FullName = "Smith";
            CheckEquals("", NameExtractor1.Title, " Title is not correct");
            CheckEquals("", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Smith", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");
            
        }
        //Business Rule 5
        public void Test5()
        {
            NameExtractor1.FullName = "Mr. Smith";
            CheckEquals("Mr", NameExtractor1.Title, " Title is not correct");
            CheckEquals("", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Smith", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");
            NameExtractor1.FullName = "Capt. Blackmore";
            CheckEquals("Capt", NameExtractor1.Title, " Title is not correct");
            CheckEquals("", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Blackmore", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");
            NameExtractor1.FullName = "Mrs Young";
            CheckEquals("Mrs", NameExtractor1.Title, " Title is not correct");
            CheckEquals("", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Young", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");
        }
        //Business Rule 6
        public void Test6()
        {
            NameExtractor1.FullName = "Kate More";
            CheckEquals("", NameExtractor1.Title, " Title is not correct");
            CheckEquals("Kate", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("More", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");
            NameExtractor1.FullName = "Pete Blackberry Mitchell";
            CheckEquals("", NameExtractor1.Title, " Title is not correct");
            CheckEquals("Pete", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("Blackberry", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Mitchell", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("", NameExtractor1.Suffix, " Suffix is not correct");
            
        }
        //Business Rule 7
        public void Test7()
        {
            NameExtractor1.FullName = "Mirs Kate More, PhD";
            CheckNotEquals("Mirs", NameExtractor1.Title, " Title is not correct");
            NameExtractor1.FullName = "Peter Blackberry Mitchell, Esq";
            CheckNotEquals("Peter", NameExtractor1.Title, " Title is not correct");
            CheckEquals("Peter", NameExtractor1.FirstName, " First Name is not correct");
            CheckEquals("Blackberry", NameExtractor1.MiddleName, " Middle Name is not correct");
            CheckEquals("Mitchell", NameExtractor1.LastName, " Last Name is not correct");
            CheckEquals("Esq", NameExtractor1.Suffix, " Suffix is not correct");

        }
        //Business Rule 8
        public void Test8()
        {
            NameExtractor1.FullName = "Kate More, PhiD";
            CheckEquals("", NameExtractor1.Title, " Title is not correct");
            CheckNotEquals("PhiD", NameExtractor1.Suffix, " Suffix is not correct");
            NameExtractor1.FullName = "Peter Blackberry Mitchell, Esq";
            CheckEquals("", NameExtractor1.Title, " Title is not correct");
            CheckEquals("Esq", NameExtractor1.Suffix, " Suffix is not correct");

        }
    }
}
