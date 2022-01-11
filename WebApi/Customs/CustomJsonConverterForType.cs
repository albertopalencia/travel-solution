﻿using System;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace WebApi.Customs
{
    public class CustomJsonConverterForType : JsonConverter<Type>
    {
        public override Type Read(   ref Utf8JsonReader reader,  Type typeToConvert, JsonSerializerOptions options  )
        {
            // Caution: Deserialization of type instances like this 
            // is not recommended and should be avoided
            // since it can lead to potential security issues.

            // If you really want this supported (for instance if the JSON input is trusted):
         //   string assemblyQualifiedName = reader.GetString();
          //  return Type.GetType(assemblyQualifiedName);
          return null;
        }

        public override void Write(  Utf8JsonWriter writer,  Type value,  JsonSerializerOptions options  )
        {
            var assemblyQualifiedName = value.AssemblyQualifiedName;
            writer.WriteStringValue(assemblyQualifiedName);
        }
    }
}
