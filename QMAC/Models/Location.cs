using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace QMAC.Models
{
    class Location
    {
        ObservableCollection<string> _sites;

        public Location()
        {
            _sites = getSites();
        }

        public ObservableCollection<string> Sites
        {
            get { return _sites; }
        }

        private ObservableCollection<String> getSites()
        {
            ObservableCollection<string> site_list = new ObservableCollection<string>();
            site_list.Add("Collinsville High School");
            site_list.Add("Crossville Elem School");
            site_list.Add("Crossville Middle School");
            site_list.Add("Crossville High School");
            site_list.Add("Fyffe High School");
            site_list.Add("Geraldine High School");
            site_list.Add("Henagar School");
            site_list.Add("Ider High School");
            site_list.Add("Moon Lake Elem School");
            site_list.Add("Plainview High School");
            site_list.Add("Ruhama School");
            site_list.Add("Sylvania High School");
            site_list.Add("Tech School (DCTC)");
            site_list.Add("Valley Head High School");

            site_list.Add("Test Location 1");
            site_list.Add("Test Location 2");
            return site_list;
        }
    }
}
