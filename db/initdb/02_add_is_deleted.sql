ALTER TABLE table_persons
    ADD COLUMN
        is_deleted BOOLEAN NOT NULL DEFAULT FALSE;