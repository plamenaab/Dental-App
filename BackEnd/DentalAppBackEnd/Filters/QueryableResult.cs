using System;
using System.Linq;
using AutoQueryable.Extensions;
using AutoQueryable.Helpers;
using AutoQueryable.Models;
using DentalApp.Api.Models.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace DentalApp.Filters
{
    public class QueryableResult : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null) return;

            dynamic query = ((ObjectResult)context.Result).Value;
            if (query == null) throw new Exception("Unable to retreive value of IQueryable from context result.");
            Type entityType = query.GetType().GenericTypeArguments[0];

            var commands = context.HttpContext.Request.Query.ContainsKey("commands") ? context.HttpContext.Request.Query["commands"] : new StringValues();

            var toArray = typeof(Enumerable).GetMethod("ToArray").MakeGenericMethod(typeof(object));

            var fetchedData = toArray.Invoke(null, new object[] { query });

            var total = System.Linq.Queryable.Count(query);
            context.Result = new OkObjectResult(new DataResult { Data = fetchedData, Total = total });
        }
    }
}
