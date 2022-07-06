using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RSoft.Lib.Data.MongoDb.Documents
{

    /// <summary>
    /// NoSql Document base object
    /// </summary>
    public class DocumentBase : IDocument
    {

        /// <inheritdoc/>
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

    }
}
