namespace TestWebApp.Models
{
    public class LanguageEntity : ICodebookEntityWithDescription
    {
        public short Id { get; set; }
        public string Code { get; set; }
        public string Iso6391 { get; set; }
        public string Iso6392 { get; set; }
        public string Description { get; set; }
        public string ResourceKey { get; set; }
    }
}
