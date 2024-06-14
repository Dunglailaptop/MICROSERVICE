-- CreateTable
CREATE TABLE "UserPermission" (
    "IdUserPermission" SERIAL NOT NULL,
    "CodeUserPermission" VARCHAR(50) NOT NULL,
    "NameRole" VARCHAR(50) NOT NULL,
    "Status" BOOLEAN NOT NULL DEFAULT true,
    "DateCreate" TIMESTAMP(3) NOT NULL DEFAULT CURRENT_TIMESTAMP,
    "DateUpdate" TIMESTAMP(3) NOT NULL,

    CONSTRAINT "UserPermission_pkey" PRIMARY KEY ("IdUserPermission")
);
