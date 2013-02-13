using System;


	/// <summary>
	/// Summary description for Login.
	/// </summary>
	public class Login
	{		
		#region --All private variable--
		private string sUserID;
		private string sPassword;
		private string sUserName;
		private bool bCheckStatus;
		private string cUserType;
		private string sEmail;
		private string ipAddress;
		private string textPassword;
		private string sPWDUnEncrypted;
		private string sOldPWD;
        private int emailCount;
        private int commentCount;
        private string extendedUserType;


		#endregion

		#region --To create all the properties--
		// To set UserID for Login page
		public string UserID
		{
			get
			{
				return sUserID;
				
			}
			set
			{
				sUserID = value;
			}
		}

		//To get or set the PWD  of user
		public string Password
		{
			get
			{
				return sPassword;
			}
			set
			{
				sPassword = value;
			}
		}

		//To get status of user validation
		public bool Status
		{
			get
			{
				return bCheckStatus;
			}
			set
			{
				bCheckStatus = value;
			}
		}

		//To get Name of user 
		public string UserName
		{
			get
			{
				return sUserName;
			}
			set
			{
				sUserName = value;
			}
		}
		//To get Type of user 
		public string UserType
		{
			get
			{
				return cUserType;
			}
			set
			{
				cUserType = value;
			}
		}

		// To set Email for Login page
		public string EMail
		{
			get
			{
				return sEmail;
				
			}
			set
			{
				sEmail = value;
			}
		}

		// Get or set text password 21 April 05
		public string TextPassword
		{
			get
			{
				return textPassword;
			}
			set
			{
				textPassword = value;
			}
		}

		// Get or set education 6May05 
		public string IPAddress
		{
			get
			{
				return ipAddress;
			}
			set
			{
				ipAddress = value;
			}
		}
		//To get or set the UnEncrypted PWD  of user
		public string PWDUnEncrypted
		{
			get
			{
				return sPWDUnEncrypted;
			}
			set
			{
				sPWDUnEncrypted = value;
			}
		}
		public string OldPWD
		{
			get
			{
				return sOldPWD;
			}
			set
			{
				sOldPWD = value;
			}
		}
        public int EmailCount
        {
            get { return emailCount; }
            set { emailCount = value; }
        }
        public int CommentCount
        {
            get { return commentCount; }
            set { commentCount = value; }
        }
        public string ExtendedUserType
        {
            get { return extendedUserType; }
            set { extendedUserType = value; }
        }
		#endregion		
	}

