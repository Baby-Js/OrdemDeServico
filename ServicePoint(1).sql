drop database ServicePoint;

create database ServicePoint;
use ServicePoint;

-- 1. Tabela Cliente
CREATE TABLE Cliente (
    id_cliente INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    cpf VARCHAR(14) NOT NULL UNIQUE, -- CPF deve ser único
    email VARCHAR(100),
    telefone VARCHAR(15),
    endereco VARCHAR(100)
);

-- 2. Tabela Aparelho
CREATE TABLE Aparelho (
    id_aparelho INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    id_cliente INT NOT NULL,
    marca VARCHAR(50) NOT NULL,
    modelo VARCHAR(50) NOT NULL,
    numero_serie VARCHAR(50), -- Opcional, pode ser NULL
    
    -- Criação do vínculo (Chave Estrangeira)
    CONSTRAINT fk_aparelho_cliente FOREIGN KEY (id_cliente) 
    REFERENCES Cliente(id_cliente)
);

-- 3. Tabela OS (Ordem de Serviço)
CREATE TABLE OS (
    id_os INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    id_aparelho INT NOT NULL,
    data_abertura DATETIME DEFAULT CURRENT_TIMESTAMP, -- Pega a data/hora atual
    data_fechamento DATETIME, -- Pode ser nulo se não acabou
    status ENUM('Analise', 'Conserto', 'Finalizado') DEFAULT 'Analise',
    defeito_relatado TEXT, -- TEXT cabe mais coisa que VARCHAR
    defeito_constatado TEXT,
    solucao_realizada TEXT,
    valor_total DECIMAL(10, 2), -- Ex: 150.50
    
    -- Criação do vínculo
    CONSTRAINT fk_os_aparelho FOREIGN KEY (id_aparelho) 
    REFERENCES Aparelho(id_aparelho)
);


----------------------------------------------------------------------------------------------------------------------------


-- Inserção de Clientes
INSERT INTO Cliente (nome, cpf, email, telefone, endereco) VALUES
('Ana Clara da Silva', '123.456.789-01', 'ana.clara@email.com', '(11) 98765-4321', 'Rua das Flores, 100'),
('Bruno Fernandes Souza', '987.654.321-02', 'bruno.fs@provedor.net', '(21) 99887-7665', 'Avenida Principal, 55'),
('Carla Gomes Oliveira', '111.222.333-44', 'carla.oliveira@outlook.com', '(31) 97766-5544', 'Travessa da Saudade, 12'),
('Daniel Rodrigues Lima', '555.444.333-22', 'daniel.rl@servico.com.br', '(41) 96543-2109', 'Praça da Liberdade, 7'),
('Eliane Pereira Santos', '000.111.222-33', 'eliane.p@gmail.com', '(51) 95432-1098', 'Rua Beco Diagonal, 20');

-- Inserção de Aparelhos (vinculados aos Clientes)
INSERT INTO Aparelho (id_cliente, marca, modelo, numero_serie) VALUES
-- Aparelhos da Ana (ID 1)
(1, 'Samsung', 'Galaxy S21', 'SN-S21-A1B2C3D4'),
(1, 'Apple', 'iPad Pro 11', 'SN-IPAD-E5F6G7H8'),

-- Aparelho do Bruno (ID 2)
(2, 'Dell', 'XPS 13', 'SN-XPS-9I0J1K2L'),

-- Aparelho da Carla (ID 3)
(3, 'Xiaomi', 'Mi Watch Lite', NULL), -- Exemplo sem número de série

-- Aparelho do Daniel (ID 4)
(4, 'Motorola', 'Moto G8 Plus', 'SN-MG8-M3N4O5P6'),

-- Aparelhos da Eliane (ID 5)
(5, 'HP', 'Pavilion x360', 'SN-HP-Q7R8S9T0'),
(5, 'Samsung', 'Galaxy Tab A7', 'SN-GTA-U1V2W3X4');

-- Inserção de Ordens de Serviço (vinculadas aos Aparelhos)

-- OS 1: Celular Ana (ID Aparelho 1) - FINALIZADA (Pagamento R$ 350.00)
INSERT INTO OS (id_aparelho, data_abertura, data_fechamento, status, defeito_relatado, defeito_constatado, solucao_realizada, valor_total) VALUES
(1, '2025-10-01 10:30:00', '2025-10-05 15:45:00', 'Finalizado',
 'Tela trincada e falha no carregamento.',
 'Tela LCD danificada e conector de carga oxidado.',
 'Troca do conjunto frontal (tela e display) e substituição do conector de carga.',
 350.00);

-- OS 2: Tablet Ana (ID Aparelho 2) - CONSERTO (Aguardando peça - Sem valor total ainda)
INSERT INTO OS (id_aparelho, data_abertura, status, defeito_relatado, defeito_constatado, solucao_realizada) VALUES
(2, '2025-11-10 09:00:00', 'Conserto',
 'Não liga após queda.',
 'Curto-circuito na placa-mãe, componente de alimentação danificado.',
 'Identificação e isolamento do curto. Pedido de componente em andamento.');

-- OS 3: Notebook Bruno (ID Aparelho 3) - ANALISE (Recém-aberta)
INSERT INTO OS (id_aparelho, data_abertura, status, defeito_relatado) VALUES
(3, DEFAULT, 'Analise',
 'Está lento e superaquecendo muito.');

-- OS 4: Tablet Eliane (ID Aparelho 7) - FINALIZADA (Pagamento R$ 120.50)
INSERT INTO OS (id_aparelho, data_abertura, data_fechamento, status, defeito_relatado, defeito_constatado, solucao_realizada, valor_total) VALUES
(7, '2025-09-15 14:00:00', '2025-09-17 11:00:00', 'Finalizado',
 'Não conecta no Wi-Fi.',
 'Defeito no módulo de comunicação wireless.',
 'Substituição do módulo Wi-Fi.',
 120.50);

-- OS 5: Celular Daniel (ID Aparelho 5) - CONSERTO (Valor parcial definido R$ 80.00)
INSERT INTO OS (id_aparelho, data_abertura, status, defeito_relatado, defeito_constatado, valor_total) VALUES
(5, '2025-11-20 16:30:00', 'Conserto',
 'Bateria não dura um dia inteiro.',
 'Capacidade da bateria em 60% da original.',
 80.00);

-- OS 6: Smartwatch Carla (ID Aparelho 4) - FINALIZADA (Serviço simples R$ 50.00)
INSERT INTO OS (id_aparelho, data_abertura, data_fechamento, status, defeito_relatado, defeito_constatado, solucao_realizada, valor_total) VALUES
(4, '2025-10-25 10:00:00', '2025-10-25 12:00:00', 'Finalizado',
 'Pulseira soltou.',
 'Pino da pulseira quebrado.',
 'Substituição e ajuste da nova pulseira.',
 50.00);


