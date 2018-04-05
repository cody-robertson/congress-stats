# File: xmlParse.py
# Description: A set of functions for parsing congress data from structured files and storing them in an access database
# Author: Cody Robertson
# Date: 4/4/18

import pyodbc
import xml.etree.ElementTree as ET
import os

class BillStatus:
    congress = 0
    billType = ""
    originChamber = ""
    billNumber = 0
    title = ""
    introducedDate = ""
    createDate = ""
    updateDate = ""
    policyArea = ""
    billSummary = ""

    def printBill(self):
        print("congress", self.congress)
        print("billType", self.billType)
        print("originChamber", self.originChamber)
        print("billNumber", self.billNumber)
        print("title", self.title)
        print("intro", self.introducedDate)
        print("create", self.createDate)
        print("update", self.updateDate)
        print("policyArea", self.policyArea)
        print("billSummary", self.billSummary)

class CongressMember:
    memberID = ""
    firstName = ""
    lastName = ""
    state = ""
    district = 0
    party = ""
    yearElected = ""
    email = ""
    address = ""
    website = ""
    phone = ""

    def printMember(self):
        print(self.memberID)
        print(self.firstName)
        print(self.lastName)
        print(self.state)
        print(self.district)
        print(self.party)
        print(self.yearElected)
        print(self.email)
        print(self.address)
        print(self.website)
        print(self.phone)

def parseBillData(path):
    print(path)
    tree = ET.parse(path)
    root = tree.getroot()

    billStatus = BillStatus()

    billStatus.congress = root[0].find('congress').text
    billStatus.billType = root[0].find('billType').text
    billStatus.originChamber = root[0].find('originChamber').text
    billStatus.billNumber = root[0].find('billNumber').text
    billStatus.title = root[0].find('title').text
    
    introducedDate = root[0].find('introducedDate').text
    createDate = root[0].find('createDate').text
    updateDate = root[0].find('updateDate').text
    
    billStatus.introducedDate = introducedDate[:10]
    billStatus.createDate = createDate[:10]
    billStatus.updateDate = updateDate[:10]

    if (len(root[0].find('policyArea')) > 0):
        billStatus.policyArea = root[0].find('policyArea')[0].text
    if (len(root[0].find('summaries')[0]) > 0):
        billStatus.billSummary = root[0].find('summaries')[0][0].find('text').text

    return billStatus

def storeBillData(billStatus):
    drivers = [x for x in pyodbc.drivers() if x.startswith('Microsoft Access Driver')]
    driver = 'Microsoft Access Driver (*.mdb, *.accdb)'

    if (driver not in drivers):
        print("Error: database driver not found")
        print("Please install Microsoft Access Driver (*.mdb, *.accdb)")
        return

    conn_str = (
        r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};'
        r'DBQ=C:\Users\25169\source\repos\software-engineering\CongressStats\CongressStats.accdb;'
        )
    connection = pyodbc.connect(conn_str)
    cursor = connection.cursor()
    for table_info in cursor.tables(tableType='TABLE'):
        print(table_info.table_name)
    
    cursor.execute("""
               insert into BillStatus (Congress, BillType, OriginChamber, BillNumber,
               IntroducedDate, Title, CreateDate, UpdateDate, PolicyArea, BillSummary)
               values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
               """, billStatus.congress, billStatus.billType, billStatus.originChamber, billStatus.billNumber,
                   billStatus.introducedDate, billStatus.title, billStatus.createDate,
                   billStatus.updateDate, billStatus.policyArea, billStatus.billSummary)

    connection.commit()
    cursor.close()
    connection.close()

def loadBillData():
    # parse and store all scraped xml files
    for root, dirs, files in os.walk("C:/Users/25169/source/repos/software-engineering/CongressStats/BILLSTATUS/"):
        for file in files:
            if file.endswith(".xml"):
                billStatus = parseBillData(os.path.join(root, file))
                storeBillData(billStatus)

def storeSenatorData(congressMember):
    drivers = [x for x in pyodbc.drivers() if x.startswith('Microsoft Access Driver')]
    driver = 'Microsoft Access Driver (*.mdb, *.accdb)'

    if (driver not in drivers):
        print("Error: database driver not found")
        print("Please install Microsoft Access Driver (*.mdb, *.accdb)")
        return

    conn_str = (
        r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};'
        r'DBQ=C:\Users\25169\source\repos\software-engineering\CongressStats\CongressStats.accdb;'
        )
    connection = pyodbc.connect(conn_str)
    cursor = connection.cursor()
    for table_info in cursor.tables(tableType='TABLE'):
        print(table_info.table_name)
    
    cursor.execute("""
               insert into CongressMembers (MemberID,FirstName, LastName, State,
               Party, Email, Address, Website, Phone)
               values (?, ?, ?, ?, ?, ?, ?, ?, ?)
               """, congressMember.memberID, congressMember.firstName, congressMember.lastName, congressMember.state,
                   congressMember.party, congressMember.email, congressMember.address, congressMember.website, congressMember.phone)

    connection.commit()
    cursor.close()
    connection.close()

def loadSenators():
    tree = ET.parse("C:/Users/25169/Desktop/senators_cfm.xml")
    root = tree.getroot()


    members = root.findall('member')
    for member in members:
        congressMember = CongressMember()
        congressMember.firstName = member.find('first_name').text
        congressMember.lastName = member.find('last_name').text
        congressMember.party = member.find('party').text
        congressMember.state = member.find('state').text
        congressMember.address = member.find('address').text
        congressMember.phone = member.find('phone').text
        congressMember.email = member.find('email').text
        congressMember.website = member.find('website').text
        congressMember.memberID = member.find('bioguide_id').text

        storeSenatorData(congressMember)

def storeRepresentativeData(member):
    drivers = [x for x in pyodbc.drivers() if x.startswith('Microsoft Access Driver')]
    driver = 'Microsoft Access Driver (*.mdb, *.accdb)'

    if (driver not in drivers):
        print("Error: database driver not found")
        print("Please install Microsoft Access Driver (*.mdb, *.accdb)")
        return

    conn_str = (
        r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};'
        r'DBQ=C:\Users\25169\source\repos\software-engineering\CongressStats\CongressStats.accdb;'
        )
    connection = pyodbc.connect(conn_str)
    cursor = connection.cursor()
    for table_info in cursor.tables(tableType='TABLE'):
        print(table_info.table_name)
    
    cursor.execute("""
               insert into CongressMembers (MemberID,FirstName, LastName, State, District,
               Party, Address)
               values (?, ?, ?, ?, ?, ?, ?)
               """, member.memberID, member.firstName, member.lastName, member.state, member.district,
                   member.party, member.address)

    connection.commit()
    cursor.close()
    connection.close()

def fixRepresentatives():
    drivers = [x for x in pyodbc.drivers() if x.startswith('Microsoft Access Driver')]
    driver = 'Microsoft Access Driver (*.mdb, *.accdb)'

    if (driver not in drivers):
        print("Error: database driver not found")
        print("Please install Microsoft Access Driver (*.mdb, *.accdb)")
        return

    conn_str = (
        r'DRIVER={Microsoft Access Driver (*.mdb, *.accdb)};'
        r'DBQ=C:\Users\25169\source\repos\software-engineering\CongressStats\CongressStats.accdb;'
        )
    connection = pyodbc.connect(conn_str)
    cursor = connection.cursor()
    
    cursor.execute("""
               UPDATE CongressMembers SET MemberType = ? WHERE not (District = ?)
               """, "representative", 0)

    connection.commit()
    cursor.close()
    connection.close()

def loadRepresentatives():
    file = open("C:/Users/25169/Desktop/excel-labels-115.csv")

    for line in file:
        items = line.split(',')
        member = CongressMember()

        # Prefix,FirstName,MiddleName,LastName,Suffix,Address,City,State,Zip+4,115 St/Dis,BioguideID,Party
        member.firstName = items[1]
        member.lastName = items[3]
        if (items[4] != ""):
            member.lastName += " " + items[4]
        member.address = items[5] + " " + items[6] + ", " + items[7] + " " + items[8]
        member.state = items[9][:2]
        member.district = items[9][2:4]
        member.memberID = items[10]
        member.party = items[11]

        storeRepresentativeData(member)
