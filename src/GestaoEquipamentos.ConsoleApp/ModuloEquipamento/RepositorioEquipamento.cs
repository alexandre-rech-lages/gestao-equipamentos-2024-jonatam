﻿namespace GestaoEquipamentos.ConsoleApp.ModuloEquipamento
{
    internal class RepositorioEquipamento
    {
        private Equipamento[] ListaEquipamentos;

        public RepositorioEquipamento()
        {
            ListaEquipamentos = new Equipamento[20];
        }
        public bool ListaEstaVazia()
        {
            int contador = 0;
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] != null)
                    contador++;
            }
            return contador == 0;
        }
        public bool InserirEquipamento(Equipamento equipamento)
        {
            bool conseguiuInserir = false;

            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] is null)
                {
                    ListaEquipamentos[i] = equipamento;
                    conseguiuInserir = true;
                    break;
                }
            }

            return conseguiuInserir;
        }

        public void MostrarEquipamentos()
        {
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] != null)
                {
                    ListaEquipamentos[i].MostrarEquipamento();
                }
            }
        }

        public void EditarEquipamento(string nomeEquipamento, Equipamento novoEquipamento)
        {
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] is not null && ListaEquipamentos[i].RetornaNome() == nomeEquipamento)
                {
                    ListaEquipamentos[i] = novoEquipamento;
                }
            }
        }

        public void RemoverEquipamento(string nomeEquipamento)
        {
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] is not null && ListaEquipamentos[i].RetornaNome() == nomeEquipamento)
                {
                    ListaEquipamentos[i] = null;
                }
            }
        }
        public bool EquipamentoExiste(string nomeEquipamento)
        {
            for (int i = 0; i < ListaEquipamentos.Length; i++)
            {
                if (ListaEquipamentos[i] is not null && ListaEquipamentos[i].RetornaNome() == nomeEquipamento)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
