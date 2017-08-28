using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSE2
{
    public class MaterialEditorViewModel
    {
        public ObservableCollection<MaterialViewModel> Materials { get; set; }

        public MaterialViewModel SelectedMaterial { get; set; }

        public MaterialEditorViewModel()
        {
            Materials = new ObservableCollection<MaterialViewModel>();
            foreach (Material material in MaterialManager.Instance.MaterialList)
            {
                Materials.Add(new MaterialViewModel(material));
            }
        }
    }
}
