﻿namespace NZWork.API.Model.DTO
{
    public class AddworkRequistDto
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImgUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
