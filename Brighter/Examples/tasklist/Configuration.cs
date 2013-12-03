﻿using OpenRasta.Codecs;
using OpenRasta.Configuration;
using Tasklist.Adapters.API.Handlers;
using Tasklist.Adapters.API.Resources;

namespace Tasklist
{
    public class Configuration : IConfigurationSource
    {
        public void Configure()
        {
            using (OpenRastaConfiguration.Manual)
            {
                ResourceSpace.Has.ResourcesOfType<TaskModel>()
                        .AtUri("/task/{id}")
                        .HandledBy<TaskEndPointHandler>()
                        .TranscodedBy<JsonDataContractCodec>()
                        .ForMediaType("application/json")
                        .ForExtension("js")
                        .ForExtension("json");
            }
        }
    }
}