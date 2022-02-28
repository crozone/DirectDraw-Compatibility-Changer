using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectDrawCompatibilityChanger {
    public class GameListItem {
        public string Name { get; set; }
        public CompatibilityInformation CompatibilityInformation { get;set;}

        public override string ToString() {
            return this.Name;
        }
    }
}
