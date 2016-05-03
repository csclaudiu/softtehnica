using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DATA;

namespace DATA
{
    [MetadataType(typeof(LocationMetadata))]
    public partial class location
    {
    }

    [MetadataType(typeof(ProductMetadata))]
    public partial class product
    {
    }

    [MetadataType(typeof(ClientMetadata))]
    public partial class client
    {
    }
}