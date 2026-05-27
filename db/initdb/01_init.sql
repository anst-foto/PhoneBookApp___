CREATE TABLE table_persons(
    id SERIAL PRIMARY KEY,
    last_name TEXT NOT NULL CHECK (last_name <> ''),
    first_name TEXT NOT NULL CHECK (first_name <> '')
);

CREATE TABLE table_phones(
    id SERIAL PRIMARY KEY,
    person_id INTEGER NOT NULL,
    phone_number TEXT NOT NULL UNIQUE,
    FOREIGN KEY (person_id) REFERENCES table_persons(id)
        ON UPDATE RESTRICT
        ON DELETE RESTRICT
);

CREATE VIEW view_phonebook AS
    SELECT table_phones.id AS "id",
            CONCAT(table_persons.last_name, table_persons.first_name, ' ') AS "full_name",
            phone_number AS "number"
    FROM table_phones
    JOIN table_persons
        ON table_phones.person_id = table_persons.id;