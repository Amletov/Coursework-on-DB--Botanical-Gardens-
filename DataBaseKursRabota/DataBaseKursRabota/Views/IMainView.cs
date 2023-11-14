using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseKursRabota.Views
{
    public interface IMainView
    {
        //Справочники
        event EventHandler ShowCityView;
        event EventHandler ShowPositionView;
        event EventHandler ShowPropertyView;
        event EventHandler ShowCareProductView;
        event EventHandler ShowFamilyView;
        //Таблицы
        event EventHandler ShowGeneraView;
        event EventHandler ShowPlantView;
        event EventHandler ShowCatalogueView;
        event EventHandler ShowEmployeeView;
        event EventHandler ShowGardenView;
        event EventHandler ShowServiceView;
        //Запросы
        event EventHandler ShowQueriesView;

        void Show();
    }
}
