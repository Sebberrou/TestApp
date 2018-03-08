using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.ViewModels
{
    public class Value
    {
        public string Name { get;set;}
        public string id { get;set; }
    }
    public class Param
    {
        public Value CurrentValue { get; set; }
        public List<Value> Values { get; set; }
    } 
    public class SettingsViewModel : BaseViewModel
    {
        private Param param1;
        public Param Param1 {
            get
            {
                return param1;
            }
            set
            {
                param1 = value;
            }
        }
        public Value Param1Value
        {
            get
            {
                if(Param1 != null)
                    return Param1.CurrentValue;
                return null;
            }
            set
            {
                System.Diagnostics.Debug.WriteLine(value.id);
                //Update things
                Param1.CurrentValue = value;
            }
        }
        public SettingsViewModel()
        {
            var vals = new List<Value>()
            {
                new Value { Name = "Toto", id = "1" },
                new Value { Name = "Titi", id = "2" },
                new Value { Name = "Tete", id = "3" },
                new Value { Name = "Tata", id = "4" },
                new Value { Name = "Tutu", id = "5" }
            };
            Param1 = new Param {
                CurrentValue = new Value { Name = "Tutu", id = "5" },
                Values = vals
            };
        }

    }
}
