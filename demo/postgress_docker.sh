docker run --name pgsql -e POSTGRES_PASSWORD=Pass123# -d postgres

docker run -e ‘PGADMIN_DEFAULT_EMAIL=test@domain.local’ -e ‘PGADMIN_DEFAULT_PASSWORD=Pass123$’ -p 8080:80 –name pgadmin4-dev dpage/pgadmin4