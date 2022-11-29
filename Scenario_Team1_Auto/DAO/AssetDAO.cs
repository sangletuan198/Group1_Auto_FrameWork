namespace Scenario_Team1_Auto.DAO
{
    public class AssetDAO
    {
        public string assetId { get; set; }
        public string name { get; set; }
        public string specification { get; set; }
        public string state { get; set; }
        public AssetDAO(string assetId, string name, string specification, string state)
        {
            this.assetId = assetId;
            this.name = name;
            this.specification = specification;
            this.state = state;
        }
    }
    public class AssetsDAO
    {
        public List<AssetDAO> content { get; set; }
    }
}
