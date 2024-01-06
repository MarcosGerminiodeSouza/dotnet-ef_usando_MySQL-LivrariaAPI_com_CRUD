using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using livrariaAPI.Context;
using livrariaAPI.Models;
using livrariaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPI.Services.LivroService
{
    public class LivroService : ILivroInterface
    {
        private readonly LivrariaContext _context;

        public LivroService(LivrariaContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<Livro>>> CriarLivro(Livro novoLivro)
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();

            try
            {
                if (novoLivro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoLivro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Livros.ToList();
                serviceResponse.Menssagem = $"Livro de id: {novoLivro.idt_livro} registrado com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Livro>>> ObterLivros()
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();
            try
            {
                serviceResponse.Dados = _context.Livros.ToList();
                serviceResponse.Menssagem = $"Total de {serviceResponse.Dados.Count} registros encontrados.";

                if (serviceResponse.Dados.Count == 0)
                    serviceResponse.Menssagem = "Nenhum registro encontrado!";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<Livro>> ObterLivroPorId(int id)
        {
            ServiceResponse<Livro> serviceResponse = new ServiceResponse<Livro>();

            try
            {
                Livro livro = _context.Livros.FirstOrDefault(x => x.idt_livro == id);

                if (livro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Livro não encontrado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = livro;
                serviceResponse.Menssagem = "Livro encontrado com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Livro>>> EditarLivro(Livro editadoLivro)
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();

            try
            {
                Livro livro = _context.Livros.AsNoTracking().FirstOrDefault(x => x.idt_livro == editadoLivro.idt_livro);

                if (livro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Livro não encontrado!";
                    serviceResponse.Sucesso = false;
                }

                _context.Livros.Update(editadoLivro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Livros.ToList();
                serviceResponse.Menssagem = $"Livro id {livro.idt_livro} editado com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Livro>>> AtivaLancamentoLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();

            try
            {
                Livro livro = _context.Livros.FirstOrDefault(x => x.idt_livro == id);

                if (livro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Livro não encontrado!";
                    serviceResponse.Sucesso = false;                    
                }

                livro.ind_lancamento = "s";

                _context.Livros.Update(livro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Livros.ToList();
                serviceResponse.Menssagem = $"Livro id {livro.idt_livro} adicionado a lista de lançamentos com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Livro>>> InativaLancamentoLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();

            try
            {
                Livro livro = _context.Livros.FirstOrDefault(x => x.idt_livro == id);

                if (livro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Livro não encontrado!";
                    serviceResponse.Sucesso = false;                    
                }

                livro.ind_lancamento = "n";

                _context.Livros.Update(livro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Livros.ToList();
                serviceResponse.Menssagem = $"Livro id {livro.idt_livro} removido da lista de lançamentos com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Livro>>> DeletarLivro(int id)
        {
            ServiceResponse<List<Livro>> serviceResponse = new ServiceResponse<List<Livro>>();

            try
            {
                Livro livro = _context.Livros.FirstOrDefault(x => x.idt_livro == id);

                if (livro == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Menssagem = "Livro não encontrado!";
                    serviceResponse.Sucesso = false;                    
                }

                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Livros.ToList();
                serviceResponse.Menssagem = $"Livro id {livro.idt_livro} deletado com sucesso!";
            }
            catch (Exception ex)
            {
                serviceResponse.Menssagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}