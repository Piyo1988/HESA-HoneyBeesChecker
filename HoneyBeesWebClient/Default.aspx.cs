using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HoneyBeesLibrary;



namespace HoneyBeesWebClient
{
    public partial class _Default : Page
    {
        List<QueenBees> qblist = new List<QueenBees>();
        List<WorkerBees> wblist = new List<WorkerBees>();
        List<DroneBees> dblist = new List<DroneBees>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                try
                {
                    //calling the belwo mehtod to create 10 instances of each type of Bee
                    CreateBeesInstances(10, out qblist, out wblist, out dblist);
                    Session["qbList"] = qblist;
                    Session["wblist"] = wblist;
                    Session["dblist"] = dblist;

                    foreach (var item in qblist)
                    {
                        lbBeesStatus.Items.Add(string.Format("Queen: Health%-{0} and is{1}", item.Health, item.Status));

                    }
                    lbBeesStatus.Items.Add(Environment.NewLine);
                    foreach (var item in wblist)
                    {
                        lbBeesStatus.Items.Add(string.Format("Worker: Health%-{0} and is{1}", item.Health, item.Status));

                    }
                    lbBeesStatus.Items.Add(Environment.NewLine);
                    foreach (var item in dblist)
                    {
                        lbBeesStatus.Items.Add(string.Format("Drone: Health%-{0} and is{1}", item.Health, item.Status));

                    }
                    lbBeesStatus.Items.Add(Environment.NewLine);

                }
                catch (Exception ex)
                {
                    //writes error to webpage as error logging not implemented as of now
                    Response.Write(ex.Message.ToString());
                }
            }            
        }

        public void CreateBeesInstances(int counter, out List<QueenBees> qblst, out List<WorkerBees> wblst, out List<DroneBees> dblst)
        {
            //creating instances of each type of Bees
            for (int i = 0; i < counter; i++)
            {
               this.qblist.Add(new QueenBees());                
               this.wblist.Add(new WorkerBees());                
                this.dblist.Add(new DroneBees());                              
            }

            qblst = this.qblist;
            wblst = this.wblist;
            dblst = this.dblist;
        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                //using Random class to generate a number between 0 to 80 to implement the Damage function logic for each kind of Bees
                Random rnd = new Random();
                if (lbBeesStatus.Items.Count > 0)
                {
                    if (Session["qblist"] != null)
                    {
                        foreach (var item in (List<QueenBees>)Session["qblist"])
                        {
                            item.Damage(rnd.Next(0, 80));
                            string response = item.Status == "Dead" ? string.Format("Queen: {0}", item.Status) : string.Format("Queen: Health%-{0} and is{1}", item.Health, item.Status);
                            lbUpdatedBeesStatus.Items.Add(response);
                        }
                        lbUpdatedBeesStatus.Items.Add(Environment.NewLine);
                    }

                    if (Session["wblist"] != null)
                    {
                        foreach (var item in (List<WorkerBees>)Session["wblist"])
                        {
                            item.Damage(rnd.Next(0, 80));
                            string response = item.Status == "Dead" ? string.Format("Worker: {0}", item.Status) : string.Format("Worker: Health%-{0} and is{1}", item.Health, item.Status);
                            lbUpdatedBeesStatus.Items.Add(response);
                        }
                        lbUpdatedBeesStatus.Items.Add(Environment.NewLine);
                    }

                    if (Session["dblist"] != null)
                    {
                        foreach (var item in (List<DroneBees>)Session["dblist"])
                        {
                            item.Damage(rnd.Next(0, 80));
                            string response = item.Status == "Dead" ? string.Format("Drone: {0}", item.Status) : string.Format("Drone: Health%-{0} and is{1}", item.Health, item.Status);
                            lbUpdatedBeesStatus.Items.Add(response);
                        }
                        lbUpdatedBeesStatus.Items.Add(Environment.NewLine);
                    }

                }
            }
            catch(Exception ex)
            {
                //writes error to webpage as error logging not implemented as of now
                Response.Write(ex.Message.ToString());
            }


        }
    }
}