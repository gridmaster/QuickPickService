using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace QuickPickService.Models
{
    public class QuickPick
    {
        [JsonProperty(PropertyName = "max")]
        public int Max {get; set;}
        public int Picks {get ; set;}
        public int PBMax { get; set; }
        public string Faves {get; set;}
        public int PBFave { get; set; }
        public int Tix {get; set;}

    }
}

	// Example REST GET's 
	// http://localhost:7001/com.firefly.rest/api/v1/numbers/49/6?tix=500
	// http://localhost:7001/com.firefly.rest/api/v1/numbers/75/6/36?faves=11,19
	// http://localhost:7001/com.firefly.rest/api/v1/numbers/49/6?faves=11,19&tix=5
    //@Path("/{max}/{picks}")
    //@GET
    //@Produces(MediaType.APPLICATION_JSON)
    //public Response returnNumbers(
    //                @PathParam("max") Integer max ,
    //                @PathParam("picks") Integer picks,
    //                @QueryParam("faves") String faves,
    //                @QueryParam("tix") Integer tix,
    //                @Context Request request,
    //                @Context UriInfo ui)
    //                throws Exception {

	// Example REST GET's
	// http://localhost:7001/com.firefly.rest/api/v1/numbers/75/5/36?tix=10
	// http://localhost:7001/com.firefly.rest/api/v1/numbers/75/5/36?faves=11,19
	// http://localhost:7001/com.firefly.rest/api/v1/numbers/75/5/36?faves=11,19&pbFave=3&tix=5
    //@Path("/{max}/{picks}/{pmax}")
    //@GET
    //@Produces(MediaType.APPLICATION_JSON)
    //public Response returnPBNumbers(
    //                @PathParam("max") Integer max ,
    //                @PathParam("picks") Integer picks,
    //                @PathParam("pmax") Integer pmax,
    //                @QueryParam("faves") String faves,
    //                @QueryParam("pbFave") String pbFave,
    //                @QueryParam("tix") Integer tix,
    //                @Context Request request,
    //                @Context UriInfo ui)