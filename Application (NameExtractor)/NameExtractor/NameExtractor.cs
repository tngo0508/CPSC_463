using System;
using System.Collections.Generic;
using System.Text;

namespace NameExtractor
{
 
       class NameExtractor
    {
            //constructor
        public NameExtractor()
        {
            mWords = new System.String[5];
        }
        # region public properties
            public String FullName
        {
            get { return mFullName; }
            set { SetFullName(value); }
        }
            //read-only properties
            public String Title
        {
            get { return mTitle; }
        }
            public String FirstName
        {
            get { return mFirstName; }
        }
            public String MiddleName
        {
            get { return mMiddleName; }
        }
            public String LastName
        {
            get { return mLastName; }
        }
            public String Suffix
        {
            get { return mSuffix; }
        }
        #endregion

        //private members
        private String mFullName;//full name
        private String mTitle;
        private String mFirstName;
        private String mMiddleName;
        private String mLastName;
        private String mSuffix;
        private String[] mWords; //array of the words obtained from the mFullName
        private Int32 mNumWords; //the number of words in the mFullName
        private void SetFullName(String Value)
        {
            if (Value != mFullName)
            {
                mFullName = Value;
                ParseName();
            }
        }
      
        //protected members
        protected void ExtractWords(String Value)
        {
            Char[] separators = { ' ', ',', '.', ':', '\t' };
            String[] words;
            //use the System.String.Split method 
            //to divide an input string into separate words
            words = Value.Split(separators);
            String[] words1 = new String[5];
            //exclude empty words (if any)
            int i = 0, k = 0;
            while ((i <= words.Length - 1) && (k <= 4))
            {
                {
                    if (words[i] == "") { i++; continue; };

                    words1[k] = words[i];
                    mNumWords = k+1;
                    k++;
                    i++;
                }
            }
       //now the words1 array contains 5 or less words
            mWords = words1;
        }

        protected void ParseName()
        {
            //initial values
            mTitle = "";
            mFirstName = "";
            mMiddleName = "";
            mLastName = "";
            mSuffix = "";
           /* You can throw exception if the name does not contain any word
            if ((mFullName == null) || (mFullName == "") )
            {
                ENameExtractorError ENameExtractorError1 = new ENameExtractorError("The Full name is not specified.");
                throw ENameExtractorError1;
            }
            */
            if ((mFullName != null) && (mFullName != ""))
            {
                ExtractWords(mFullName);
                FindTitle();
                FindSuffix();
                FindLastName();
                FindFirstName();
                FindMiddleName();
            }
        }      
       
        protected Int32 FindTitle()
        {
            //0 - the title might be the first word only
            if (mWords != null)
            {
                if (Suff__Title_Lists.TitleList.Contains(mWords[0]))
                {
                    mTitle = mWords[0];
                    return 0;
                }
                else
                {
                    return -1;//no title
                };
            }
            return -1;
        }
        protected Int32 FindSuffix()
        {
            if (mWords[4] != null)
            {
                mSuffix = mWords[4];
                return 0;
            }
            else
            {
                if ((mWords[2] != null) && (Suff__Title_Lists.SuffixList.Contains(mWords[2])))
                {
                    mSuffix = mWords[2];
                    return 0;
                }
                if ((mWords[3] != null) && (Suff__Title_Lists.SuffixList.Contains(mWords[3])))
                {
                    mSuffix = mWords[3];
                    return 0;
                }
            }
            return -1;
        }

        protected Int32 FindFirstName()
        {
            if ((mNumWords >= 2) && (mTitle == ""))
            {
                mFirstName = mWords[0];
                return 0;
            }
            if ((mNumWords > 2) && (mTitle != ""))
            {
                mFirstName = mWords[1];
                return 0;
            }
            if (mNumWords == 5) 
            { mFirstName = mWords[1]; 
                return 0;
            }
            return -1; // no first name

        }
        protected Int32 FindMiddleName()
        {
            if ((mNumWords == 5) || ((mNumWords == 4) && (mSuffix == "")))
            {
                mMiddleName = mWords[2];
                return 0;
            } 
            if (((mNumWords ==4) && (mTitle =="") ) || ((mNumWords == 4) && (mSuffix == ""))) 
            {
                mMiddleName = mWords[1];
                return 0;
            }
            
            //think!!!
            if ((mNumWords == 3) && (mSuffix == "") && (mTitle == ""))
            {
                mMiddleName = mWords[1];
            }

           
            return -1; //no middle name
            
        }
        protected Int32 FindLastName()
        {
            if (mNumWords == 1)
            {mLastName = mWords[0];
                return 0;
            }
            if  (mNumWords == 2) 
            {
                mLastName = mWords[1];
                return 0;
            }
            if (mNumWords == 5)
            {
                mLastName = mWords[3];
                return 0;
            }
            if (((mNumWords == 3) && (mSuffix == "")) ||
                (mNumWords == 4) && (mSuffix != ""))
            {
                mLastName = mWords[2];
                return 0;
            }
            else
            {
                if (mNumWords == 3) { mLastName = mWords[1]; }
                else {if (mNumWords == 4) { mLastName = mWords[3]; } }
                return 0;
            }  
            return -1;
        }
     
    }
    class ENameExtractorError : Exception
    {
        public ENameExtractorError(String Message)
        {          
        }
    }
   
}
