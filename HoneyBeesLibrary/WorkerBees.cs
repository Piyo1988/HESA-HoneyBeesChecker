using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyBeesLibrary
{
   public class WorkerBees
    {
        public double Health { get; set; }
        public string Status = "Alive";
        private double minHealth = 70;
        

        public WorkerBees()
        {
            this.Health = 100;
        }


        public void Damage(int randomReductioninHealth)
        {
            try
            {
                if ((randomReductioninHealth > 0) && (randomReductioninHealth < 100))
                {
                    if (this.Health >= minHealth)
                    {
                        var result = this.Health - randomReductioninHealth;
                        this.Health = Convert.ToDouble(result);
                        this.Status = this.Health >= minHealth ? "Alive" : "Dead";
                    }
                    else
                    {
                        this.Status = "Dead";
                    }
                }
            }

            catch (Exception ex)
            {
                //throws exception as error logging not implemented as of now

            }
        }
    }
}
