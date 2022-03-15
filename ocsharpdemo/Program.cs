using System;
using System.IO;

using owncloudsharp;
using owncloudsharp.Types;

namespace ocsharpdemo
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            //var c = new Client ("https://octest.myvpx.de/owncloud10", "demo", "demo");
            var c = new Client("http://192.168.12.146/nextcloud/", "nxstudio", "nx@82279602");
            /**Console.Write ("Testing DAV:List ... ");
			var list = c.List ("/");
			Console.WriteLine ("Received " + list.Count + " item(s)");
			foreach (var item in list) {
				if (!item.ContentType.Equals ("dav/directory")) {
					Console.Write ("Testing DAV:Downloading: " + item.Path + "/" + item.Name + " ... ");
					var data = c.Download (item.Path + "/" + item.Name);
					Console.WriteLine (data.Length + " Bytes received");
					BinaryReader reader = new BinaryReader (data);
					data.Position = 0;
					byte[] rdata = reader.ReadBytes ((int)data.Length);
					File.WriteAllBytes (item.Name, rdata);
					if (!c.Exists ("/demo"))
						c.CreateDirectory ("/demo");
					Console.Write ("Testing DAV:Uploading " + item.Name + " to /demo/ ... ");
					var status = c.Upload ("/demo/" + item.Name, new MemoryStream (rdata), item.ContentType);
					if (status)
						Console.WriteLine ("DONE");
					else
						Console.WriteLine ("FAILED");
					Console.Write ("Testing DAV:Deleting " + item.Name + " from /demo/ ... ");
					status = c.Delete ("/demo/" + item.Name);
					if (status)
						Console.WriteLine ("DONE");
					else
						Console.WriteLine ("FAILED");
				} else
					continue;
			}*/

            /**
            var list = c.GetUsers();
            foreach (var item in list)
            {
                var subadmin = c.IsUserInSubAdminGroup(item, item);
            }

            Console.Write ("Testing OCS:ListOpenRemoteShare ... ");
            if (!c.Exists("/demo"))
                c.CreateDirectory("/demo");

            
            var a = c.CreateUser("test", "D8!di7As1");
            a = c.CreateUser("demo001", "D8!di7As0");
            a = c.CreateGroup("Test123");
            a = c.AddUserToGroup("test", "Test123");
            
            if (!(c.UserExists("test"))) c.CreateUser("test", "D8!di7As1");
            if (!(c.UserExists("demo001"))) c.CreateUser("demo001", "D8!di7As0");
            if (!(c.GroupExists("Test123"))) c.CreateGroup("Test123");
            if (!(c.IsUserInGroup("test", "Test123"))) c.AddUserToGroup("test", "Test123");
            */
            var s = c.ShareWithLink("/Nextcloud.mp4", (int)OcsPermission.All);
            var ps = c.ShareWithLink("/Nextcloud.mp4", Convert.ToInt32(OcsPermission.All), "de@82279602@mo", OcsBoolParam.True);     // 密碼要合要求
            var us = c.ShareWithUser("/demo", "test", Convert.ToInt32(OcsPermission.All), OcsBoolParam.False);
            var gs = c.ShareWithGroup("/demo", "Test123", Convert.ToInt32(OcsPermission.All));
            var result = c.IsShared("/demo") ? "is shared" : "is not shared";
			Console.WriteLine ("/demo " + result + ".");
            var r1 = c.SetUserAttribute("demo001", OCSUserAttributeKey.Password , "D8!di7Ab9"); // "D8!di7As1"
            Console.WriteLine(r1);
            Console.ReadLine();
        }
    }
}
