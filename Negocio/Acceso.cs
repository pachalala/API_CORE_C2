using Microsoft.Extensions.Configuration;
using Models;
using System.Data;
using System.DirectoryServices;
//using System.Reflection.PortableExecutable;
using System.Text;

namespace   Negocio
{
    public class Acceso
    {


        public Acceso()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }


        private string _filterAttribute;


         



        bool es_tipo(string path, string tipo)
        {

            return path.IndexOf(tipo) == -1 ? false : true;

        }

         


        static public SearchResult ProcesaAcceso(string IdUsu)
        {
            string domain = "FOSIS";
            string username = "serp.admin";
            string pwd = "serp.fosis10";
            string path = "";

            // 

            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(path,
            domainAndUsername, pwd);
            // try
            {
                // Bind to the native AdsObject to force authentication. 
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + IdUsu + ")";
                search.PropertiesToLoad.Add("cn");
                search.PropertiesToLoad.Add("mail");
                search.PropertiesToLoad.Add("cnname");
                search.PropertiesToLoad.Add("samAccountName");
                search.PropertiesToLoad.Add("displayName");
                search.PropertiesToLoad.Add("givenName");
                search.PropertiesToLoad.Add("samaccountname");

                search.PropertiesToLoad.Add("description");




                //   search.Filter = "(&(objectCategory=person)(objectClass=user))";
                //search.Filter = "(OU=Municipios*)";

                // SearchResultCollection result = search.FindAll();// ..FindOne();
                SearchResult result = search.FindOne();// ..FindOne();

                if (null == result)
                {
                    return result;
                }





                return result;//.Properties["adspath"][0].ToString();



            }

        }




        public Usuario_AD VerificarAcceso(string domain, string username, string pwd, string path)
        {

            Usuario_AD usuario = new Usuario_AD();


            string domainAndUsername = domain + @"\" + username;
            DirectoryEntry entry = new DirectoryEntry(path,
            domainAndUsername, pwd);
            try
            {
                // Bind to the native AdsObject to force authentication. 
                Object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + username + ")";
                search.PropertiesToLoad.Add("cn");
                search.PropertiesToLoad.Add("displayname");

                //search.PropertiesToLoad.Add("mail");

                SearchResult result = search.FindOne();
                if (null == result)
                {
                    return usuario;
                }


             

                path = result.Path;
                _filterAttribute = (String)result.Properties["cn"][0];
                try
                {
                   usuario.Nombre = result.Properties["displayname"][0].ToString();
                }

                catch
                {
                }
                Array ss;
                int cantidad;
                ss = path.Split(',');
                usuario.usuario =  (String)result.Properties["cn"][0];
                cantidad = ((string[])(ss))[1].Length;
                //HttpContext.Current.Session["Region"] = ((string[])(ss))[1].Substring(3, cantidad - 3);
                usuario.Region  = path;
                usuario.User= username.ToString();


            }
            catch (Exception ex)
            {
                throw new Exception("Error authenticating user. " + ex.Message);
                return usuario;
            }
            return usuario;
        }

        public string GetGroups(string path)
        {
            DirectorySearcher search = new DirectorySearcher(path);
            search.Filter = "(cn=" + _filterAttribute + ")";
            search.PropertiesToLoad.Add("memberOf");
            StringBuilder groupNames = new StringBuilder();
            try
            {
                SearchResult result = search.FindOne();
                int propertyCount = result.Properties["memberOf"].Count;
                String dn;
                int equalsIndex, commaIndex;
                for (int propertyCounter = 0; propertyCounter < propertyCount;
                  propertyCounter++)
                {
                    dn = (String)result.Properties["memberOf"][propertyCounter];
                    equalsIndex = dn.IndexOf("=", 1);
                    commaIndex = dn.IndexOf(",", 1);
                    if (-1 == equalsIndex)
                    {
                        return null;
                    }
                    groupNames.Append(dn.Substring((equalsIndex + 1),
                    (commaIndex - equalsIndex) - 1));
                    groupNames.Append("|");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error obtaining group names. " + ex.Message);
            }
            return groupNames.ToString();
        }



       

      


        public static Usuario_AD accesos(string txtDomainName, string txtUserName, string txtPassword)
        {
            string adPath = Environment.GetEnvironmentVariable("dlap");


            Usuario_AD usuario = null;

        //    try
            {

                /*
                if (HttpContext.Current.Session["Usuario"].ToString() == txtUserName.ToString())
                {
                    return "";
                }
                */

                Acceso Ver = new Acceso();


                usuario = Ver.VerificarAcceso(txtDomainName.ToString(), txtUserName.ToString(), txtPassword.ToString(), adPath);
                    
                   

            }
          /*  catch (Exception ex)
            {
                string Respuesta = ex.Message;
                return Respuesta;
            }
          */
            return usuario;
        }



    }
}
