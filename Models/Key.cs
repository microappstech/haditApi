using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace haditApi.Models
{
    /// <summary>
    /// no one know the use of this even me :-)
    /// </summary>
    [Keyless]
    public class Key
    {
        [Required]
        public string KeyValue { get; set; }
    }
}
