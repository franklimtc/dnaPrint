namespace Site.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeldnaPrint : DbContext
    {
        public ModeldnaPrint()
            : base("name=ModeldnaPrint")
        {
        }

        public virtual DbSet<CadastroCidade> CadastroCidade { get; set; }
        public virtual DbSet<CadastroEquipamentoModelo> CadastroEquipamentoModelo { get; set; }
        public virtual DbSet<CadastroEquipamentos> CadastroEquipamentos { get; set; }
        public virtual DbSet<CadastroEstado> CadastroEstado { get; set; }
        public virtual DbSet<CadastroSetor> CadastroSetor { get; set; }
        public virtual DbSet<CadastroUnidade> CadastroUnidade { get; set; }
        public virtual DbSet<vw_disponibilidade3> vw_disponibilidade3 { get; set; }
        public virtual DbSet<vw_bilhetagemAtual> vw_bilhetagemAtual { get; set; }
        public virtual DbSet<vw_suprimentos2> vw_suprimentos2 { get; set; }
        public virtual DbSet<vw_ErrosEquipamentos> vw_ErrosEquipamentos { get; set; }
        public virtual DbSet<tempBilhetagemSemanal> tempBilhetagemSemanal { get; set; }

        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<ArquivoImpresso> ArquivoImpresso { get; set; }
        public virtual DbSet<VW_VolumeMensalPorEquip> VW_VolumeMensalPorEquip { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            #region Tabela de Cadastros

            modelBuilder.Entity<CadastroCidade>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroEquipamentoModelo>()
                .Property(e => e.Fabricante)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroEquipamentoModelo>()
                .Property(e => e.Modelo)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroEquipamentoModelo>()
                .Property(e => e.valorExcedente)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CadastroEquipamentos>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroEquipamentos>()
                .Property(e => e.serie)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroEquipamentos>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroEstado>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroEstado>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroSetor>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroSetor>()
                .Property(e => e.centroCusto)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroSetor>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.endereco)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.contato)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.razaoSocial)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.cnpj)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.ie)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.fax)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUnidade>()
                .Property(e => e.email)
                .IsUnicode(false);

            #endregion

            //Adicionado vw_disponibilidade3

            #region VwDisponibilidade

            modelBuilder.Entity<vw_disponibilidade3>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<vw_disponibilidade3>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<vw_disponibilidade3>()
                .Property(e => e.Unidade)
                .IsUnicode(false);

            modelBuilder.Entity<vw_disponibilidade3>()
                .Property(e => e.Cod)
                .IsUnicode(false);

            modelBuilder.Entity<vw_disponibilidade3>()
                .Property(e => e.Ambiente)
                .IsUnicode(false);

            modelBuilder.Entity<vw_disponibilidade3>()
                .Property(e => e.Fila)
                .IsUnicode(false);

            modelBuilder.Entity<vw_disponibilidade3>()
                .Property(e => e.serie)
                .IsUnicode(false);

            modelBuilder.Entity<vw_disponibilidade3>()
                .Property(e => e.ip)
                .IsUnicode(false);
            #endregion

            //Adicionado BilhetagemAtual

            #region Bilhetagem

            modelBuilder.Entity<vw_bilhetagemAtual>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<vw_bilhetagemAtual>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<vw_bilhetagemAtual>()
                .Property(e => e.local)
                .IsUnicode(false);

            modelBuilder.Entity<vw_bilhetagemAtual>()
                .Property(e => e.CC)
                .IsUnicode(false);

            modelBuilder.Entity<vw_bilhetagemAtual>()
                .Property(e => e.setor)
                .IsUnicode(false);

            modelBuilder.Entity<vw_bilhetagemAtual>()
                .Property(e => e.serie)
                .IsUnicode(false);

            modelBuilder.Entity<vw_bilhetagemAtual>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<vw_bilhetagemAtual>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<vw_bilhetagemAtual>()
                .Property(e => e.Modelo)
                .IsUnicode(false);
            #endregion

            // Adicionando vw_suprimentos2

            #region VwSuprimentos

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.Unidade)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.Cod)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.Ambiente)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.Fila)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.serie)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.ip)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.PostagemToner)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.PostagemCilindro)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.serialToner)
                .IsUnicode(false);

            modelBuilder.Entity<vw_suprimentos2>()
                .Property(e => e.serialFoto)
                .IsUnicode(false);
#endregion

            //Adicionando view de erros

            #region VW_ErrosEquipamentos
            modelBuilder.Entity<vw_ErrosEquipamentos>()
                .Property(e => e.UF)
                .IsUnicode(false);

            modelBuilder.Entity<vw_ErrosEquipamentos>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<vw_ErrosEquipamentos>()
                .Property(e => e.Unidade)
                .IsUnicode(false);

            modelBuilder.Entity<vw_ErrosEquipamentos>()
                .Property(e => e.Cod)
                .IsUnicode(false);

            modelBuilder.Entity<vw_ErrosEquipamentos>()
                .Property(e => e.Ambiente)
                .IsUnicode(false);

            modelBuilder.Entity<vw_ErrosEquipamentos>()
                .Property(e => e.Fila)
                .IsUnicode(false);

            modelBuilder.Entity<vw_ErrosEquipamentos>()
                .Property(e => e.serie)
                .IsUnicode(false);

            modelBuilder.Entity<vw_ErrosEquipamentos>()
                .Property(e => e.ip)
                .IsUnicode(false);
            #endregion

            // Adicionando Usuarios

            #region Usuarios
            modelBuilder.Entity<Usuarios>()
               .Property(e => e.nome)
               .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.senha)
                .IsUnicode(false);
            #endregion

            //Adicionando Arquivos Impressos

            #region ArquivosImpressos
            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.DataType)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.Document)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.DriverName)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.MachineName)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.NotifyUserName)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.PaperKind)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.PaperSource)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.Parameters)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.PrinterName)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.PrinterResolutionKind)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.PrintProcessorName)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.StatusDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.TimeWindow)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ArquivoImpresso>()
                .Property(e => e.server)
                .IsUnicode(false);
            #endregion

            //Adicionado VW_VolumeMensalPorEquip

            #region VW_VolumeMensalPorEquip
            modelBuilder.Entity<VW_VolumeMensalPorEquip>()
                .Property(e => e.Modelo)
                .IsUnicode(false);
            #endregion

        }
    }
}
