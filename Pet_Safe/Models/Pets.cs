﻿namespace Pet_Safe.Models
{
    public class Pets
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}