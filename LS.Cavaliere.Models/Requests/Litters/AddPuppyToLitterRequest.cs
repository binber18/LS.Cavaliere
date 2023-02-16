using LS.Cavaliere.Models.Requests.Files;

namespace LS.Cavaliere.Models.Requests.Litters;

public record AddPuppyToLitterRequest(string Name, FileRequest Image);