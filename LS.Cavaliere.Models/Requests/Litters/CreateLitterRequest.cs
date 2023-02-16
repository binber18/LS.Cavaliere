using LS.Cavaliere.Models.Requests.Files;

namespace LS.Cavaliere.Models.Requests.Litters;

public record CreateLitterRequest(char Letter, string Father, string Mother, FileRequest ParentImage);