using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
using System.Collections.Specialized;

// =========================================================================================================================================
//                      bbbbbbbb                                                                                                          
// XXXXXXX       XXXXXXXb::::::b                                                  SSSSSSSSSSSSSSS DDDDDDDDDDDDD       KKKKKKKKK    KKKKKKK
// X:::::X       X:::::Xb::::::b                                                SS:::::::::::::::SD::::::::::::DDD    K:::::::K    K:::::K
// X:::::X       X:::::Xb::::::b                                               S:::::SSSSSS::::::SD:::::::::::::::DD  K:::::::K    K:::::K
// X::::::X     X::::::X b:::::b                                               S:::::S     SSSSSSSDDD:::::DDDDD:::::D K:::::::K   K::::::K
// XXX:::::X   X:::::XXX b:::::bbbbbbbbb       ooooooooooo xxxxxxx      xxxxxxxS:::::S              D:::::D    D:::::DKK::::::K  K:::::KKK
//    X:::::X X:::::X    b::::::::::::::bb   oo:::::::::::oox:::::x    x:::::x S:::::S              D:::::D     D:::::D K:::::K K:::::K   
//     X:::::X:::::X     b::::::::::::::::b o:::::::::::::::ox:::::x  x:::::x   S::::SSSS           D:::::D     D:::::D K::::::K:::::K    
//      X:::::::::X      b:::::bbbbb:::::::bo:::::ooooo:::::o x:::::xx:::::x     SS::::::SSSSS      D:::::D     D:::::D K:::::::::::K     
//      X:::::::::X      b:::::b    b::::::bo::::o     o::::o  x::::::::::x        SSS::::::::SS    D:::::D     D:::::D K:::::::::::K     
//     X:::::X:::::X     b:::::b     b:::::bo::::o     o::::o   x::::::::x            SSSSSS::::S   D:::::D     D:::::D K::::::K:::::K    
//    X:::::X X:::::X    b:::::b     b:::::bo::::o     o::::o   x::::::::x                 S:::::S  D:::::D     D:::::D K:::::K K:::::K   
// XXX:::::X   X:::::XXX b:::::b     b:::::bo::::o     o::::o  x::::::::::x                S:::::S  D:::::D    D:::::DKK::::::K  K:::::KKK
// X::::::X     X::::::X b:::::bbbbbb::::::bo:::::ooooo:::::o x:::::xx:::::x   SSSSSSS     S:::::SDDD:::::DDDDD:::::D K:::::::K   K::::::K
// X:::::X       X:::::X b::::::::::::::::b o:::::::::::::::ox:::::x  x:::::x  S::::::SSSSSS:::::SD:::::::::::::::DD  K:::::::K    K:::::K
// X:::::X       X:::::X b:::::::::::::::b   oo:::::::::::oox:::::x    x:::::x S:::::::::::::::SS D::::::::::::DDD    K:::::::K    K:::::K
// XXXXXXX       XXXXXXX bbbbbbbbbbbbbbbb      ooooooooooo xxxxxxx      xxxxxxx SSSSSSSSSSSSSSS   DDDDDDDDDDDDD       KKKKKKKKK    KKKKKKK
// =========================================================================================================================================
// https://xboxsdk.com & https://xboxapi.com

/**
 * In this example we used Newtonsoft's JSON Parsing libarary.
 * This can be found: http://james.newtonking.com/projects/json-net.aspx
 * Thanks to James Newton-King for this great libaray.
 */
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace ExampleApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // on our form load read api.key file if it exists
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Environment.CurrentDirectory + @"\api.key"))
                apikey.Text = File.ReadAllText(Environment.CurrentDirectory + @"\api.key");
        }
        
        // function will get user info from our api
        private void GetUserInfo_Click(object sender, EventArgs e)
        {
            // our api uri
            string uri = "https://xboxsdk.com/api/user/" + apikey.Text;

            // query API get our api response
            JObject api_response = APIQuery(uri);

            // check to see if our API query was a success or not
            if ((bool)api_response["success"])
            {
                listBox1.Items.Add(" Username: \t" + api_response["data"]["user_name"]);
                listBox1.Items.Add(" Email: \t\t" + api_response["data"]["user_email"]);
                listBox1.Items.Add(" Alias: \t\t" + api_response["data"]["user_alias"]);
            }
            else
            {
                MessageBox.Show("Error: " + api_response["error"]);
            }
        }

        // function will get users profiles
        private void GetProfiles_Click(object sender, EventArgs e)
        {
            // our api uri
            string uri = "https://xboxsdk.com/api/profiles/" + apikey.Text;

            // query API and get response
            JObject api_response = APIQuery(uri);

            // check to see if our API query was a success
            if ((bool)api_response["success"])
            {   
                foreach (JObject profile in api_response["data"])
                {
                    listBox1.Items.Add("---------------- Profile ----------------");
                    listBox1.Items.Add("ID: \t\t" + profile["id"]); 
                    listBox1.Items.Add("Profile Name: \t" + profile["profile_name"]);
                    listBox1.Items.Add("Profile ID: \t" + profile["profile_id"]);
                    listBox1.Items.Add(" ");
                }
            }
            else
            {
                MessageBox.Show("Error: " + api_response["error"]);
            }
        }

        // function to download a save
        private void DownloadSave_Click(object sender, EventArgs e)
        {
            string uri = null;

            // our api uri
            if (MessageBox.Show("Do you want to resign this download with the Profile ID?", "Resign?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                uri = "https://xboxsdk.com/api/resign/" + apikey.Text + "/" + dlid.Text + "/" + pfid.Text;    
            else
                uri = "https://xboxsdk.com/api/download/" + apikey.Text + "/" + dlid.Text;

            // query API and get response
            JObject api_response = APIQuery(uri);

            // check to see if our API query was a success
            if ((bool)api_response["success"])
            {
                // listbox output
                listBox1.Items.Add("Downloading Save ID: " + dlid.Text);

                // get our real filename
                string file_name = (string)api_response["data"]["file_name"];

                // get our save file data as a base64 encoded string
                byte[] fileData = Convert.FromBase64String((string)api_response["data"]["file_data"]);

                // write ouRRRRRR byte[] array to rrRRRRR save, says pirate pete.
                System.IO.File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + file_name, fileData);

                // output
                listBox1.Items.Add("Finished" + dlid.Text);
                listBox1.Items.Add("Writing out save to: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + file_name);
            }
            else
            {
                MessageBox.Show("Error: " + api_response["error"]);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // setup some post vars
            if (txtName.Text == "" || txtDesc.Text == "")
            {
                MessageBox.Show("You must enter a save name and save description before uploading a save.", "Error!");
                return;
            }

            // in this example I used NamedValueCollection as it's a nice tidy way to store vars we can
            // then loop thorugh to setup our post data.
            NameValueCollection post_vars = new NameValueCollection();
            post_vars.Add("name", txtName.Text);
            post_vars.Add("description", txtDesc.Text);
            
            string file = null;

            // build our API uri call
            string uri = "https://xboxsdk.com/api/upload/" + apikey.Text;

            // open our save
            OpenFileDialog odlg = new OpenFileDialog();
            if (odlg.ShowDialog() == DialogResult.OK)
                file = odlg.FileName;
            else
                return;

            // read the save data into a byte array
            byte[] file_data = File.ReadAllBytes(file);

            // some output
            listBox1.Items.Add("Uploading: " + Path.GetFileName(file));

            // since this is a special requst using POST data we are NOT going to call our APIQuery function
            // we are going to do our own custom call
            //
            // for this exaple I'll still be using HttpWebRequest however we are going to customize it using ContentType as 
            // multipart/form-data and call several POST vars
            string boundary = "----------------------" + DateTime.Now.Ticks.ToString("x");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";

            // our memory stream we are going to ues to write all our form data (in a byte array) to
            // request stream.
            Stream mem_stream = new MemoryStream();

            // our form boundary (in bytes)
            byte[] boundary_bytes = Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            // this will be our template string we can use for all our post vars
            string formdata_template = "\r\n--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\";\r\n\r\n{1}";

            // loop thorugh each one of our post vars and build our byte array using our memory stream
            foreach (string key in post_vars.Keys)
            {
                // get the bytes to our formitem by building a string, then getting our bytes and 
                // writing it all to our memory stream
                byte[] formitem_data = Encoding.UTF8.GetBytes(string.Format(formdata_template, key, post_vars[key]));
                mem_stream.Write(formitem_data, 0, formitem_data.Length);
            }

            // write out post vars bounday
            mem_stream.Write(boundary_bytes, 0, boundary_bytes.Length);

            // now that we are done with the form data we need to deal with our save file (binary data)
            // the file we are going to upload
            byte[] formfile_data = Encoding.UTF8.GetBytes("Content-Disposition: form-data; name=\"save_data\"; filename=\"" + Path.GetFileName(file) + "\"\r\nContent-Type: application/octet-stream\r\n\r\n");

            // write the data to our memory stream
            mem_stream.Write(formfile_data, 0, formfile_data.Length);

            // write the files actual data to the memory stream
            mem_stream.Write(file_data, 0, file_data.Length);

            // write our file data boundary
            mem_stream.Write(boundary_bytes, 0, boundary_bytes.Length);

            // YAY all done with our request lets write it and send it
            // we need to set our content-length
            request.ContentLength = mem_stream.Length;

            // build our buffer and fill it with mem_stream data so we can send it via our new requeststream
            // reset our mem_stream pos
            mem_stream.Position = 0;
            
            byte[] send_buffer = new byte[mem_stream.Length];
            mem_stream.Read(send_buffer, 0, send_buffer.Length);
            
            // done with mem_stream
            mem_stream.Close();

            // get our request stream
            Stream dataStream = request.GetRequestStream();

            // write the data to request stream
            dataStream.Write(send_buffer, 0, send_buffer.Length);

            // close
            dataStream.Close();

            // get our API response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            // read our API response
            string json_data = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

            // deserialize our json data into a nice JObject (thanks Newtonsoft <3)
            JObject api_response = JObject.Parse(json_data);

            // check to see if our API query was a success
            if ((bool)api_response["success"])
                MessageBox.Show((string)api_response["data"]["msg"], "Success");
            else
                MessageBox.Show((string)api_response["error"], "Error");
        }


        // function to save api key to api.key file
        private void button5_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Environment.CurrentDirectory + @"\api.key", apikey.Text);
        }

        // function to clear our listbox
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }




        // APIQuery
        // function will call XboxSDK API with the passed uri and return it's response
        // note: XboxSDK will always return from within an array and will always
        //       have the "success" key with a bool value if the API call was a success
        //       or not.
        // 
        //       If the "success" key is true "data" key will be present
        //       if false then "error" will be present with a string of the error
        public JObject APIQuery(string api_uri)
        {
            if (apikey.Text == "" || apikey.Text == null)
            {
                MessageBox.Show("Error: I need an API Key");
                return null;
            }

            // build our api request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api_uri);

            // setup some reasonable limits on resources used by this request
            request.MaximumAutomaticRedirections = 4;
            request.MaximumResponseHeadersLength = 4;

            // setup credentials to use for this request.
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // get the stream associated with the response.
            Stream receiveStream = response.GetResponseStream();

            // pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            // read our API response
            string json_data = readStream.ReadToEnd();

            response.Close();
            readStream.Close();

            // deserialize our json data into a nice JObject (thanks Newtonsoft <3)
            return JObject.Parse(json_data);
        }

        
    }
    
}
