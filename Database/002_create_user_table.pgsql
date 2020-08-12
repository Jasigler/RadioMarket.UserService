CREATE TABLE Users
(
    user_id SERIAL,
    email character varying(50) UNIQUE NOT NULL,
	first_name character varying(50)  NOT NULL,
	last_name character varying(50)  NOT NULL,
    password_hash character varying(250)  NOT NULL,
    password_salt character varying(250) NOT NULL,
    CONSTRAINT "Users_pkey" PRIMARY KEY (user_id)
)

TABLESPACE pg_default;

ALTER TABLE public."Users"
    OWNER to postgres;