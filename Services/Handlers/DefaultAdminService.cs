﻿using System;
using System.Collections.Generic;
using AVDharma.LeilaoOnline.WebApp.Dados;
using AVDharma.LeilaoOnline.WebApp.Models;

namespace AVDharma.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        ILeilaoDao _leilaoDao;
        ICategoriaDao _categoriaDao;

        public DefaultAdminService(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao)
        {
            _leilaoDao = leilaoDao;
            _categoriaDao = categoriaDao;

        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _categoriaDao.BuscarTodos();
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _leilaoDao.BuscarTodos();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _leilaoDao.BuscarPorId(id);
        }

        public void CadastraLeilao(Leilao leilao)
        {
            _leilaoDao.Incluir(leilao);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            _leilaoDao.Alterar(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                _leilaoDao.Excluir(leilao);
            }
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            var leilao = _leilaoDao.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _leilaoDao.Alterar(leilao);
            }
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            var leilao = _leilaoDao.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _leilaoDao.Alterar(leilao);
            }
        }
    }
}
