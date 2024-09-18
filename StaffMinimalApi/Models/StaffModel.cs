using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace StaffMinimalApi.Models
{
    public class StaffModel
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        /// <summary>
        /// Número de funcionário.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Nome do funcionário.
        /// </summary>
        public string Nome { get; set; } = null!;

        /// <summary>
        /// Número do departamento.
        /// </summary>
        public int Departamento { get; set; }

        /// <summary>
        /// Cargo.
        /// </summary>
        public string Cargo { get; set; } = null!;

        /// <summary>
        /// Anos com a empresa.
        /// </summary>
        public int? Anos { get; set; }

        /// <summary>
        /// Salário anual do funcionário.
        /// </summary>
        public decimal Salario { get; set; }

        /// <summary>
        /// Comissão do funcionário
        /// </summary>
        public decimal? Comissao { get; set; }
    }
}
