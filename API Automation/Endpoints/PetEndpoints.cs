using API_Automation.Dtos.Common;

namespace API_Automation.Endpoints
{
    public class PetEndpoints
    {
        //pet
        public static string UploadImage(long petId) => $"pet/{petId}/uploadImage";
        public static string AddNewPet() => "pet";
        public static string UpdateExistingPet() => "pet";
        //public static string FindPetByStatus(List<PetStatus> status) => $"v2/pet/findByStatus?status={string.Join("&status=", status)}";
        public static string FindPetByStatus() => $"pet/findByStatus";
        public static string FindPetById(long petId) => $"pet/{petId}";
        public static string UpdateExistingPetWithFormData(long petId) => $"pet/{petId}";
        public static string DeletePet(long petId) => $"pet/{petId}";
    }
}
