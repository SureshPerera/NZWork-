namespace NZWork.API.Model.Domain
{
    public class Work
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImgUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        //Navigation proparty 
        public Difficulty difficulty { get; set; }
        public Region region { get; set; }
    }
}
