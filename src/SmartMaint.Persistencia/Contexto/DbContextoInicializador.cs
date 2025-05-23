﻿using SmartMaint.Compartilhado.Enums;
using SmartMaint.Dominio.Entidades;

namespace SmartMaint.Persistencia.Contexto
{
    public class DbContextoInicializador
    {
        private readonly EscritaDbContexto _contexto;

        public DbContextoInicializador(EscritaDbContexto escritaDbContexto)
        {
            _contexto = escritaDbContexto;
        }

        public void GerarConfiguracaoInicial()
        {
            _contexto.Database.EnsureCreated();

            if (!_contexto.Empresas.Any())
            {
                CriarEmpresaUsuarioMaster();
            }
        }

        private void CriarEmpresaUsuarioMaster()
        {
            var endereco = new Endereco("35680415", "Avenida Juscelino Kubitschek", "Alaíta", "Itaúna", "MG");
            var empresa = new Empresa("Smart Maint", "56928391000163", null, "379999999", "3799999999", "smartmaint@gmail.com", "143", null, endereco);
            var perfil = new Perfil("Master", ETipoPerfil.MASTER, [ETipoAcaoPerfil.CRIAR, ETipoAcaoPerfil.EDITAR, ETipoAcaoPerfil.DELETAR, ETipoAcaoPerfil.VISUALIZAR], empresa);
            var usuario = new Usuario("teste", "teste@gmail.com", "123", perfil);
            empresa.VincularUsuario(usuario);

            _contexto.Enderecos.Add(endereco);
            _contexto.Empresas.Add(empresa);
            _contexto.Perfis.Add(perfil);
            _contexto.Usuarios.Add(usuario);

            _contexto.SaveChanges();
        }
    }
}
