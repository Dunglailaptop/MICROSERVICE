import { PrismaClient } from '@prisma/client'
const { DateTime } = require('luxon');

const prisma = new PrismaClient()

async function main() {
    const now = DateTime.Now;
  
  const newRole = await prisma.role.create({
     data: {
        CodeRole: 'Admin',
        NameRole: 'Admins',
        Status: true,
        DateCreate: now,
        DateUpdate: now
     }
   });

   await prisma.users.create({
     data: {    
      CodeUsers: 'US1',  
      Username:   'NguyenXuanTienDung',
      Password: '0000',   
      Status: true,    
      DateCreate: now, 
      DateUpdate: now, 
      IdRole: newRole.IdRole     
     },
   });
}

main()
  .then(async () => {
    await prisma.$disconnect()
  })
  .catch(async (e) => {
    console.error(e)
    await prisma.$disconnect()
    process.exit(1)
  })