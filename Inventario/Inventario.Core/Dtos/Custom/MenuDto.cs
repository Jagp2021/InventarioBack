namespace Inventario.Core.Dtos.Custom
{
    public class MenuDto
    {
        public string Label { get; set; } = null!;
        public string? Icon { get; set; }
        public List<object>? RouterLink { get; set; }
        public List<MenuDto>? Items { get; set; } 
    }
}
