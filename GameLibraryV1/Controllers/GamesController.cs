using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibraryV1.Controllers
{
  
    public class GamesController
    {
        Views.IGamesView _view;

        public GamesController(Views.IGamesView view)
        {
            _view = view;
            view.SetController(this);
        }
    }

}
