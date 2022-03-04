using GDFA.Application.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDFA.Application.Model
{
    
        public class Post
        {
            public Args args { get; set; }
            public string data { get; set; }
            public Files files { get; set; }
            public Form form { get; set; }
            public Headers headers { get; set; }
            public object json { get; set; }
            public string origin { get; set; }
            public string url { get; set; }
        }

        public class Headers
        {
          
          [HeaderProperty("Content-Type")]
            public string ContentType { get; set; }// sended paramaeter type


        
        }

        public class Args { }

        public class Files { }

        public class Form { }
     
}
