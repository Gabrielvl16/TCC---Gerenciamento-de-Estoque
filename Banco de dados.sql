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

-- Tabela de Produtos (Estoque) com coluna imagem
CREATE TABLE IF NOT EXISTS produtos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    categoria VARCHAR(50) NOT NULL,
    tamanho VARCHAR(10) NOT NULL,
    cor VARCHAR(30) NOT NULL,
    quantidade INT NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    descricao TEXT,
    imagem LONGBLOB,
    data_cadastro TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Tabela de Movimentações de Estoque
CREATE TABLE IF NOT EXISTS movimentacoes_estoque (
    id INT AUTO_INCREMENT PRIMARY KEY,
    produto_id INT NOT NULL,
    tipo ENUM('Entrada', 'Saída', 'Devolução') NOT NULL,
    quantidade INT NOT NULL,
    data_movimentacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    observacao TEXT,
    FOREIGN KEY (produto_id) REFERENCES produtos(id)
);

-- Tabela de Notas Fiscais
CREATE TABLE IF NOT EXISTS notas_fiscais (
    id INT AUTO_INCREMENT PRIMARY KEY,
    produto_id INT NULL,
    numero VARCHAR(100),
    chave_acesso VARCHAR(100),
    xml LONGTEXT NULL,
    pdf_path VARCHAR(255) NULL,
    api_response TEXT NULL,
    data_emissao DATETIME,
    valor_total DECIMAL(10,2),
    criado_em TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (produto_id) REFERENCES produtos(id)
);

USE loja_roupas_2_0;

-- Produtos
INSERT INTO produtos (nome, categoria, tamanho, cor, quantidade, preco, descricao, imagem)
VALUES
('Camiseta Básica', 'Camiseta', 'M', 'Branco', 50, 29.90, 'Camiseta básica branca em algodão', NULL),
('Calça Jeans Skinny', 'Calça Jeans', '38', 'Azul Escuro', 30, 99.90, 'Calça jeans skinny feminina', NULL),
('Jaqueta de Couro', 'Jaqueta', 'G', 'Preto', 10, 199.90, 'Jaqueta estilo rock', NULL),
('Vestido Floral', 'Vestido', 'P', 'Rosa Claro', 20, 79.90, 'Vestido floral leve para verão', NULL),
('Tênis Esportivo', 'Tênis', '42', 'Cinza', 40, 149.90, 'Tênis confortável para corrida', NULL);

-- Movimentações de estoque (entradas em datas variadas)
INSERT INTO movimentacoes_estoque (produto_id, tipo, quantidade, data_movimentacao, observacao)
VALUES
(1, 'Entrada', 50, '2025-05-10 10:00:00', 'Entrada inicial do estoque'),
(2, 'Entrada', 30, '2025-06-15 15:30:00', 'Entrada para promoção de verão'),
(3, 'Entrada', 10, '2025-07-20 09:00:00', 'Nova coleção inverno'),
(4, 'Entrada', 20, '2025-08-05 14:00:00', 'Reposição de estoque'),
(5, 'Entrada', 40, '2025-08-10 11:30:00', 'Chegada de estoque novo');

-- Notas fiscais simuladas relacionadas (datas iguais às movimentações)
INSERT INTO notas_fiscais (produto_id, numero, chave_acesso, xml, pdf_path, api_response, data_emissao, valor_total)
VALUES
(1, NULL, NULL, NULL, 'caminho/nota1.pdf', 'Simulação', '2025-05-10 10:00:00', 50 * 29.90),
(2, NULL, NULL, NULL, 'caminho/nota2.pdf', 'Simulação', '2025-06-15 15:30:00', 30 * 99.90),
(3, NULL, NULL, NULL, 'caminho/nota3.pdf', 'Simulação', '2025-07-20 09:00:00', 10 * 199.90),
(4, NULL, NULL, NULL, 'caminho/nota4.pdf', 'Simulação', '2025-08-05 14:00:00', 20 * 79.90),
(5, NULL, NULL, NULL, 'caminho/nota5.pdf', 'Simulação', '2025-08-10 11:30:00', 40 * 149.90);
