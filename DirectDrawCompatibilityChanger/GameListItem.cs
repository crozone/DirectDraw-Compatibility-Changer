namespace DirectDrawCompatibilityChanger
{
    public class GameListItem {
        public string Name { get; set; }
        public CompatibilityInformation CompatibilityInformation { get;set;}

        public override string ToString() {
            return this.Name;
        }
    }
}
