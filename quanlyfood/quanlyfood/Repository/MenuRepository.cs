using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using quanlyfood.Models;

namespace quanlyfood.Repository
{
    public class MenuRepository
    {
        dbFoodLinQDataContext data = new dbFoodLinQDataContext();
        public List<MenuModel> getListMenu()
        {
            var menu_parents = from parents in data.MENUs
                               where parents.TrangThai == 1 &&
                                     parents.Parent == null
                               select new MenuModel()
                               {
                                   id = parents.id,
                                   ten = parents.Ten,
                                   slug = parents.Slug
                               };
            var menu_list = menu_parents.ToList();
            
            if (menu_list.Count() > 0)
            {
                
                foreach (var parent in menu_list)
                {
                    var menu_childs = from childs in data.MENUs
                    where childs.TrangThai == 1 &&
                          childs.Parent == parent.id
                    select new MenuModel()
                    {
                        id = childs.id,
                        ten = childs.Ten,
                        slug = childs.Slug
                    };

                    /*var menu_to_update = menu_parents.SingleOrDefault(d => d.id == parent.id);
                    menu_to_update.childrent = menu_childs.ToList();*/
                    parent.childrent = menu_childs.ToList();
                    


                }


            }

            return menu_list;



        }

    }
}