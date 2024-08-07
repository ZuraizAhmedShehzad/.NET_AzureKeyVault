namespace DotNet8_AzureKeyVault.Models
{
    public class AzureKeyVaultSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TenantId { get; set; }
        public string VaultUrl { get; set; }
    }
}
