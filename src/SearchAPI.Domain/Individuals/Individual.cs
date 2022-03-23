using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SearchAPI.Domain.Contracts;

namespace SearchAPI.Domain.Individuals
{
    public class Individual
    {
        [JsonPropertyName("nationalId")]
        public string NationalId { get; set; }
        
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        
        [JsonPropertyName("dateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        
        [JsonPropertyName("gender")]
        public string Gender { get; set; }
        
        [JsonPropertyName("contracts")]
        public ICollection<Contract> Contracts { get; set; }
    }
}