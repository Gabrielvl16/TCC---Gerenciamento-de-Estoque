-- Criação do banco de dados
CREATE DATABASE IF NOT EXISTS loja_roupas_2_0;
USE loja_roupas_2_0;

-- Tabela de Funcionários
CREATE TABLE IF NOT EXISTS funcionarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100),
    cpf VARCHAR(14),
    rg VARCHAR(20),
    data_nasc DATE,
    telefone VARCHAR(20),
    email VARCHAR(100),
    cep VARCHAR(10),
    cargo VARCHAR(50),
    departamento VARCHAR(50),
    status VARCHAR(20),
    data_admissao DATE,
    salario DECIMAL(10,2),
    carteira_trabalho VARCHAR(30),
    pis_pasep VARCHAR(30)
);

-- Tabela de Usuários
CREATE TABLE IF NOT EXISTS usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    senha VARCHAR(255) NOT NULL,
    nivel_acesso ENUM('Admin', 'Comum') NOT NULL,
    status ENUM('Ativo', 'Inativo') DEFAULT 'Ativo',
    imagem LONGBLOB
);

-- Tabela de Produtos (Estoque)
CREATE TABLE IF NOT EXISTS produtos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    categoria VARCHAR(50) NOT NULL,
    tamanho VARCHAR(10) NOT NULL,
    cor VARCHAR(30) NOT NULL,
    quantidade INT NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    descricao TEXT,
    data_cadastro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
ALTER TABLE produtos ADD imagem LONGBLOB;

CREATE TABLE IF NOT EXISTS movimentacoes_estoque (
    id INT AUTO_INCREMENT PRIMARY KEY,
    produto_id INT NOT NULL,
    tipo ENUM('Entrada', 'Saída', 'Devolução') NOT NULL,
    quantidade INT NOT NULL,
    data_movimentacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    observacao TEXT,
    FOREIGN KEY (produto_id) REFERENCES produtos(id)
);
