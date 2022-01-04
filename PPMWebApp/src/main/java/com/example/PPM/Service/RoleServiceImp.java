package com.example.PPM.Service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.example.PPM.Model.Role;
import com.example.PPM.Repo.RoleRepo;

@Service
public class RoleServiceImp implements RoleService
{

	@Autowired
	private RoleRepo repo;
	
	@Override
	public List<Role> Get() {
		return repo.findAll(); 
	}

	@Override
	public void Save(Role role) {
		repo.save(role);
	}

	@Override
	public Role GetById(int id) {
		Optional<Role> optional = repo.findById(id);
		Role role = null;
		if(optional.isPresent())
		{
			role = optional.get();
		}
		else
		{
			throw new RuntimeException("Role is not found of roleID : "+id);
		}
		
		return role;
	}

	@Override
	public void Delete(int id) {
		repo.deleteById(id);
	}

}
