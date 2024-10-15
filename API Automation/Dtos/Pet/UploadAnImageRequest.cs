namespace API_Automation.Dtos.Pet
{
    public class UploadAnImageRequest
    {
        public long PetId { get; set; } // Required pet ID to update
        public required string AdditionalMetadata { get; set; } // Additional data to pass to server
        public required string File { get; set; } // File name as string
    }
}
