
ALTER TABLE traning
ADD active VARCHAR(6) NOT NULL

ALTER TABLE address
ADD active VARCHAR(6) NOT NULL

CREATE TABLE traning(
	traning_id SMALLINT NOT NULL IDENTITY(1,1),
	date_trng DATE NOT NULL,
	time_trng TIME NOT NULL,
	duration_trng TIME NOT NULL,
	type_trng VARCHAR(15) NOT NULL,
	PRIMARY KEY (traning_id),
	jmbg_coach BIGINT NOT NULL,
	jmbg_beginner BIGINT NOT NULL,
	FOREIGN KEY(jmbg_coach) REFERENCES coach(jmbg),
	FOREIGN KEY(jmbg_beginner) REFERENCES beginner(jmbg)
);

CREATE TABLE fitness_center(
	fitness_center_id SMALLINT NOT NULL IDENTITY(1,1),
	name_center VARCHAR(40),
	address_id SMALLINT NOT NULL,
	PRIMARY KEY (fitness_center_id),
	FOREIGN KEY(address_id) REFERENCES address(address_id)
);

CREATE TABLE coach(
	jmbg BIGINT UNIQUE,
	first_name VARCHAR(15) NOT NULL,
	last_name VARCHAR(15) NOT NULL,
	gender VARCHAR(6) NOT NULL,
	email VARCHAR(50) NOT NULL,
	password VARCHAR(50) NOT NULL,
	user_type VARCHAR(13),
	active VARCHAR(6) NOT NULL,
	address_id SMALLINT NOT NULL,
	PRIMARY KEY (jmbg),
	FOREIGN KEY(address_id) REFERENCES address(address_id)
);

CREATE TABLE administrator(
	jmbg BIGINT UNIQUE,
	first_name VARCHAR(15) NOT NULL,
	last_name VARCHAR(15) NOT NULL,
	gender VARCHAR(6) NOT NULL,
	email VARCHAR(50) NOT NULL,
	password VARCHAR(50) NOT NULL,
	user_type VARCHAR(13),
	active VARCHAR(6) NOT NULL,
	address_id SMALLINT NOT NULL,
	PRIMARY KEY (jmbg),
	FOREIGN KEY(address_id) REFERENCES address(address_id)
);

CREATE TABLE address(
	address_id SMALLINT NOT NULL IDENTITY(1,1),
	street VARCHAR(40) NOT NULL,
	number SMALLINT NOT NULL,
	city VARCHAR(20) NOT NULL,
	state VARCHAR(15),
	PRIMARY KEY (address_id)
);